using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogos : MonoBehaviour
{
    public GameObject caixa;
    public GameObject dica;
    public TextAsset arq1;
    public TextAsset arq2;
    
    public string[] texto1;
    public string[] texto2;
    public Text mensagem1;
    public Text mensagem2;

    private int fimLinha1;
    private int fimLinha2;
    private int linhaAtual1;
    private int linhaAtual2;
    public bool ativo;
    public bool dialogo1;
    public bool dialogo2;

    private MoverPlayer mpScript; 
    private Helena hScript;
    // Start is called before the first frame update
    void Start()
    {
        dialogo1 = true;
        dialogo2 = false;
        hScript = GameObject.Find("Dra. Helena").GetComponent<Helena>();
        mpScript = GameObject.Find("Robo_0").GetComponent<MoverPlayer>();
        mpScript.move = false;
        dica.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogo1 == true)
        {
            primeiroDialogo();
            Pular1();
        }
        if(dialogo2 == true)
        {
            segundoDialogo();
            Pular2();
        }
    }
    void primeiroDialogo()
    {
        if(arq1 != null)
        {
            texto1 = (arq1.text.Split('\n'));
        }
        if(fimLinha1 == 0)
        {
            fimLinha1 = texto1.Length;
            mensagem1.text = texto1[linhaAtual1];
            linhaAtual1 += 1;
        }
    }
    void segundoDialogo()
    {
        Habilitar();
        mpScript.move = false;
        if(arq2 != null)
        {
            texto2 = (arq2.text.Split('\n'));
        }
        if(fimLinha2 == 0)
        {
            fimLinha2 = texto2.Length;
            mensagem2.text = texto2[linhaAtual2];
            linhaAtual2 += 1;
        }
        
        
    }
    void Pular1()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GetComponent<AudioSource>().Play();
            if(linhaAtual1 < fimLinha1)
            {
                mensagem1.text = texto1[linhaAtual1];
            }
            if(caixa.activeSelf)
            {
                linhaAtual1 += 1;
                
            }
        }
        if(linhaAtual1 > fimLinha1)
        {
            linhaAtual1 = 0;
            mensagem1.text = "    ";
            
            Desabilitar();
            dialogo1 = false;
            
            hScript.move = true;
            
        }
    }
    void Pular2()
    {
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GetComponent<AudioSource>().Play();
            if(linhaAtual2 < fimLinha2)
            {
                mensagem2.text = texto2[linhaAtual2];
                
            }
            if(caixa.activeSelf)
            {
                linhaAtual2 += 1;
            }
        }
        if(linhaAtual2 > fimLinha2)
        {
            linhaAtual2 = 0;
            mensagem2.text = "    ";
            Desabilitar();
            dialogo2 = false;
            hScript.destruir = true;
            mpScript.move = true;
            mpScript.animar = true;
            dica.SetActive(true);
        }
    }
    void Habilitar()
    {
        caixa.SetActive(true);
    }

    void Desabilitar()
    {
        caixa.SetActive(false);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    public GameObject caixa;
    public GameObject final;
    public TextAsset arq1;
    public TextAsset arq2;
    public TextAsset arq3;
    public TextAsset arq4;
    
    public TextAsset Apaga;

    public string[] texto1;
    public string[] texto2;
    public string[] texto3;
    public string[] texto4;
    
    
    public Text mensagem1;
    public Text mensagem2;
    public Text mensagem3;
    public Text mensagem4;
    

    private int fimLinha1;
    private int fimLinha2;
    private int fimLinha3;
    private int fimLinha4;
    
    
    private int linhaAtual4;
    private int linhaAtual1;
    private int linhaAtual2;
    private int linhaAtual3;
    public bool ativo;
    public bool dialogo1;
    public bool dialogo2;
    public bool dialogo3;
    public bool dialogo4;
    
    

    private MoverPlayer mpScript; 
    private Pontos ptScript;
    private Helena hScript;
    void Start()
    {
        final.SetActive(false);

        dialogo1 = true;
        mpScript = GameObject.Find("Robo_0").GetComponent<MoverPlayer>();
        ptScript = GameObject.Find("Pontuacao").GetComponent<Pontos>();
        hScript = GameObject.Find("Dra. Helena").GetComponent<Helena>();
        DialogoInicial();


    }
    
    // Update is called once per frame
    void Update()
    {
        if(dialogo1 == true)
        {
            DialogoInicial();
            Pular1();
        }
        if(dialogo2 == true)
        {
            segundoDialogo();
            Pular2();
        }
        if(dialogo3 == true)
        {
            terceiroDialogo();
            Pular3();
        }
        if(dialogo4 ==true)
        {
            QuartoDialogo();
            Pular4();
        }
        
    }
    void DialogoInicial()
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
        Time.timeScale =0;
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
    void terceiroDialogo()
    {
        Habilitar();
        Time.timeScale =0;
        if(arq3 != null)
        {
            texto3 = (arq3.text.Split('\n'));
        }
        if(fimLinha3 == 0)
        {
            fimLinha3 = texto3.Length;
            mensagem3.text = texto3[linhaAtual3];
            linhaAtual3 += 1;
        }
    }
    void QuartoDialogo()
    {
        Habilitar();
        Time.timeScale =0;
        if(arq4 != null)
        {
            texto4 = (arq4.text.Split('\n'));
        }
        if(fimLinha4 == 0)
        {
            fimLinha4 = texto4.Length;
            mensagem4.text = texto4[linhaAtual4];
            linhaAtual4 += 1;

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
            texto1 = (Apaga.text.Split('\n'));
            mensagem1.text = texto1[linhaAtual1];
            Desabilitar();
            dialogo1 = false;
            mpScript.move = true;
        
            
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
            texto2 = (Apaga.text.Split('\n'));
            mensagem2.text = texto2[linhaAtual2];
            Desabilitar();
            Time.timeScale =1;
            dialogo2 = false;
            
        }
    }
    void Pular3()
    
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GetComponent<AudioSource>().Play();
            if(linhaAtual3 < fimLinha3)
            {
                mensagem3.text = texto3[linhaAtual3];
            }
            if(caixa.activeSelf)
            {
                linhaAtual3 += 1;
            }
        }
        if(linhaAtual3 > fimLinha3)
        {
            linhaAtual3 = 0;
            texto3 = (Apaga.text.Split('\n'));
            mensagem3.text = texto3[linhaAtual3];
            Desabilitar();
            Time.timeScale =1;
            dialogo3 = false;
            mpScript.move = true;
        
            
        }
    }
    void Pular4()
    
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GetComponent<AudioSource>().Play();
            if(linhaAtual4 < fimLinha4)
            {
                mensagem4.text = texto4[linhaAtual4];
                
            }
            if(caixa.activeSelf)
            {
                linhaAtual4 += 1;
            }
        }
        if(linhaAtual4 > fimLinha4)
        {
            linhaAtual4 = 0;
            Time.timeScale =1;
            texto4 = (Apaga.text.Split('\n'));
            mensagem4.text = texto4[linhaAtual4];
            Desabilitar();
            dialogo4 = false;
            mpScript.final = true;
            hScript.move = true;
            final.SetActive(true);
            
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pontos : MonoBehaviour
{
    // Start is called before the first frame update

    public Text pontosUI;
    public Text vidasUI;
    public Text statusUI;
    public bool checkFinal;
    public int pontos = 0;

    public int vidas = 5;
    private MainScene msScript;
    private MoverPlayer mpScript; 
    void Start()
    {
        msScript = GameObject.Find("Pontuacao").GetComponent<MainScene>();
        mpScript = GameObject.Find("Robo_0").GetComponent<MoverPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        pontosUI.text = "Dados :" + pontos;
        vidasUI.text = "Vidas :" + vidas;
        if(pontos <= 25)
        {
            statusUI.text = "Dados Insuficientes, Procure no mapa.";
            statusUI.color = Color.yellow;
            
        }else
        {
            statusUI.text = "Dados Suficientes! Encontre a Dra Helena";
            statusUI.color = Color.green;
            pontosUI.color = Color.green;
        }

        if(vidas <= 0 )
        {
            vidasUI.color = Color.red;
        }
        if(checkFinal == true )
        {
            if(pontos >= 25)
            {
                msScript.dialogo4 = true;
                mpScript.destruir = true;
                checkFinal = false;
            }
            else
            {
                
                checkFinal = false;
            }
        }
    }
}

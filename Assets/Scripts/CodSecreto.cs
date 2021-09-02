using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodSecreto : MonoBehaviour
{
    //public GameObject painel;
    public InputField txtCode;
    public GameObject Hope;
    public GameObject Check;

    private Pontos ptScript;
    // Start is called before the first frame update
    void Start()
    {
        ptScript = GameObject.Find("Pontuacao").GetComponent<Pontos>();
    }
    public void Botao()
    {
        if(txtCode.text == "wilker")
        {
            Hope.transform.position = Check.transform.position; 
            txtCode.text = "";
        }
        if(txtCode.text == "dados")
        {
            ptScript.pontos = 30; 
            txtCode.text = "";
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
}

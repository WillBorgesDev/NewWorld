using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject painel;
    public GameObject Code;
    public bool isPause;
    public bool isCode;
    
    // Start is called before the first frame update
    void Start()
    {
        painel.SetActive(false);
        Code.SetActive(false);
        Time.timeScale = 1;
    }
    void InCode()
    {
        Code.SetActive(true);
    }
    void UnCode()
    {
        Code.SetActive(false);
    }
    void InPause()
    {
        Time.timeScale =0;
        painel.SetActive(true);
        
    }

    void UnPause()
    {
        Time.timeScale = 1;
        painel.SetActive(false);
    }
    public void OnClickResume()
    {
        UnPause();
        UnCode();
    }
    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.P))
        {
            isPause= !isPause;
            if(isPause)
            {
                InPause();
                
            }else
            {
                UnPause();
                UnCode();
            }

        }
        if(isPause == true )
        {
            if(Input.GetKeyDown(KeyCode.C))
                {
                    isCode = !isCode;
                    if(isCode)
                    {
                        InCode();
                    }else
                    {
                        UnCode();
                    }
                    
                }
        }

    }

    
}

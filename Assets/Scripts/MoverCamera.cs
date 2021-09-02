using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoverCamera : MonoBehaviour
{
    public GameObject player;
     
 

    void Start ()
    {
    
    }

    void LateUpdate ()
    {
        Camera.main.transform.position = new Vector3(player.transform.position.x,0,-10);
        if (player.transform.position.y >= 4.5f)
        {
            Camera.main.transform.position = new Vector3(player.transform.position.x, 4.5f,-10);
        }
        else if(player.transform.position.y <= 2.7f)
        {
            Camera.main.transform.position = new Vector3(player.transform.position.x,0,-10);
        }
    }

    
    public void OnClickStart()
     {
        SceneManager.LoadScene("Inicio");
     }
    public void OnClickReset()
     {
         SceneManager.LoadScene("MainScene");
     }
    public void OnCLickMenuPrincipal()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void OnCLickCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }
    public void OnClickExit()
    {
        Application.Quit();
    }


}

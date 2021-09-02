using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Capsula : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    public float time = 1f;
    public bool fim = false;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("null");
    }

    // Update is called once per frame
    void Update()
    {
        if(fim == true)
        {   
            anim.Play("Efeito");
            time -= Time.deltaTime;
            if(time <= 0 )
            {   
                
                anim.Play("Efeito2");
                fim = false;
            }
        }
        
        
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.tag == "Dra")
        {
            
            fim = true;
            GetComponent<AudioSource>().Play();
            
            
        }
    }
}

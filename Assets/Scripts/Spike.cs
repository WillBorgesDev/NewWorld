using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    // Start is called before the first frame update
     public int speed = -3;

    // Start is called before the first frame update
    void Start()
    {
        //Adiciona speed a velocidade do obstaculo
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);

        
    }

    void OnTriggerEnter2D(Collider2D outro)
     {
         if (outro.gameObject.tag == "Death")
         {
            Destroy(this.gameObject);
         }
     }
}

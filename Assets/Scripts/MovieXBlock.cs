using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieXBlock : MonoBehaviour
{
    public float speed = 1;
    
    Rigidbody2D body;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
            
            transform.Translate(speed * Time.deltaTime,0,0);

        
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.tag == "Limit")
        {
            speed *= -1;
        }
    }
}

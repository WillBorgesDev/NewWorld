using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helena : MonoBehaviour
{

    public float speed;
    public float direcao; 
    public bool move;
    public bool destruir = false;
    public bool naCapsula = false;
    public bool CapFinal = false;
    public float time = 3f; 
    SpriteRenderer sprite;
    Rigidbody2D body;
    Animator anim;
    Transform trans;
    AudioSource som;

    private Dialogos diaScript;
    // Start is called before the first frame update
    void Start()
    {
        diaScript = GameObject.Find("Pontuacao").GetComponent<Dialogos>();
        
        sprite = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        trans = GetComponent<Transform>();
        som = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {

        
        if(move == true)
        {
            Mover();
        }
        if(move == false)
        {
            Parar();
        }
        if(destruir == true && naCapsula == true)
        {
            Destroy(this.gameObject);
        }
        if(CapFinal == true)
        {
            time -= Time.deltaTime;
            if(time <= 0)
            {
                destruir = true;
            }
        }
        
        PlayerAnimator();
    }

    void Mover()
    {
        direcao = 2f;
        speed = 2f;
        body.velocity = new Vector2( direcao * speed , body.velocity.y); 

        
        if(direcao <= 0 && sprite.flipX == false){
           Flip();
        }
        else if(direcao > 0 && sprite.flipX == true){
            Flip();
        }
        
    }
    void Parar()
    {
        direcao = 0;
        speed = 0;

        body.velocity = new Vector2(direcao * speed, body.velocity.y);

        if(direcao <= 0 && sprite.flipX == false){
           Flip();
        }
        
       
        
    }
    void Dialogo()
    {
        diaScript.dialogo2 = true;
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if(outro.gameObject.tag == "Inicio")
        {
            GetComponent<AudioSource>().Pause();
            move = false;
            Dialogo();
            naCapsula = true;

        }
        if(outro.gameObject.tag == "CapFinal")
        {
            GetComponent<AudioSource>().Pause();
            move = false;
            naCapsula = true;
            CapFinal = true;
            
            
        }

        
    }

    void Flip()
    {
        sprite.flipX = !sprite.flipX;
    }
    void PlayerAnimator()
    {
        // Iniciando animações do player
        if(body.velocity.x == 0 && body.velocity.y == 0 )
        {
            anim.Play("HelenaIddle");
            //Inicia a animação dela parada
        }
        else if(body.velocity.x != 0 )
        {
            anim.Play("HelenaWalk");
            //Inicia a animação dela correndo 
        }else if(body.velocity.y != 0 )
        {
            anim.Play("HelenaWalk");
            //Tambem inicia a animação dela correndo mas na vertical
        }
    }
}

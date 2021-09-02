using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MoverPlayer : MonoBehaviour
{
    public float speed = 8f;
    public float direcao; 
    
    public float jumpForce = 200f;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    
    bool onFloor = false;
    bool onJump = false;
    public bool animar = false;
    public float radius = 0.5f; 
    public GameObject lastCheckpoint;
    public GameObject Moeda;
    public GameObject checkFinal;
    public bool move;
    public bool final;
    public bool destruir = false;
    
    
    private Pontos ptScript;
    private MainScene msScript;
    public AudioClip[] clip;


    

   //public float timeSlow = 3.0f; 

    SpriteRenderer sprite;
    Rigidbody2D body;
    Animator anim;
    Transform trans;
    AudioSource som;
    
    // Start is called before the first frame update
    void Start()
    {   
        final = false; 
        
        ptScript = GameObject.Find("Pontuacao").GetComponent<Pontos>();
        msScript = GameObject.Find("Pontuacao").GetComponent<MainScene>();
        
        sprite = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        trans = GetComponent<Transform>();
        som = GetComponent<AudioSource>();
        

    }

    // Update is called once per frame
    void Update()
    {
        onFloor = Physics2D.OverlapCircle (groundCheck.position, radius,  whatIsGround);

        //onFloor = Physics2D.Linecast (transform.position, groundCheck.position, whatIsGround);
        if(move == true)
        {
            Mover();
        }else
        {
            anim.Play("Idle");
        }
        if(destruir == true)
        {
            Destroy(checkFinal);
        }
        if(final == true)
        {
            moveFinal();
        }
        if(animar == true)
        {
            PlayerAnimator1();
        }
                   
    }
    
    void Mover()
    {
        if (Input.GetButtonDown("Jump") && onFloor == true)
        {
            anim.Play("Jump");
            onJump = true;
            
            if(Time.timeScale == 1)
            {
                som.clip = clip[0];
                som.Play();
                
            }
            
        }


        float horizontal = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(horizontal * speed , body.velocity.y); 

        
        if(horizontal < 0 && sprite.flipX == false){
           Flip();
        }
        else if(horizontal > 0 && sprite.flipX == true){
            Flip();
        }

        if(onJump)
            body.AddForce(new Vector2 (0f, jumpForce));
            
            onJump = false;
        
        PlayerAnimator();
        
    }
    public void moveFinal()
    {
        direcao = 1.5f;
        body.velocity = new Vector2( direcao * speed , body.velocity.y); 

        
        if(direcao < 0 && sprite.flipX == false){
           Flip();
        }
        else if(direcao > 0 && sprite.flipX == true){
            Flip();
            
        }

        if(onJump)
            body.AddForce(new Vector2 (0f, jumpForce));
            onJump = false;
        
        PlayerAnimator();
    }
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "MovieBLock")
        {
            trans.parent = collision.transform;
        }
    }

    public virtual void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.tag == "MovieBLock")
        {
            trans.parent = null;
        }
    }


    void OnTriggerEnter2D(Collider2D outro)
    {

        if(outro.gameObject.tag == "Checkpoint")
        {
            lastCheckpoint = outro.gameObject; 
        }
        if (outro.gameObject.tag == "Death")
        {
            transform.position = lastCheckpoint.transform.position;
            ptScript.vidas = ptScript.vidas - 1; 
            
        }
        
        if (outro.gameObject.tag == "Flower")
        {
            Moeda = outro.gameObject;
            ptScript.pontos = ptScript.pontos + 1;
            som.clip = clip[1];
            som.Play();
            
            Destroy(Moeda);
        }
        if(outro.gameObject.tag == "fstFlower")
        {
            msScript.dialogo2 = true;
            Destroy(outro.gameObject);
        }

        if(outro.gameObject.tag == "FstCheck")
        {
            msScript.dialogo3 = true;
            Destroy(outro.gameObject);
        }
        if(outro.gameObject.tag == "FinalCheck")
        {
            ptScript.checkFinal = true;
            checkFinal = outro.gameObject;
            if(destruir == true)
            {
                
                Destroy(outro.gameObject);
            }
        }
        if (outro.gameObject.tag == "Inicio")
        {
            SceneManager.LoadScene("MainScene");
        }
        if(outro.gameObject.tag == "CapFinal")
        {
            SceneManager.LoadScene("Creditos");    
            final = false;
        }
        
    }
    void Flip()
    {
        sprite.flipX = !sprite.flipX;
    }

    void PlayerAnimator1()
    {
        
        if(body.velocity.x == 0 && body.velocity.y == 0)
        {
            anim.Play("Idle");
        }else if(body.velocity.x != 0)
        {
            anim.Play("Walk");
            //Inicia a animação dela correndo 
        }
    }
    void PlayerAnimator()
    {
        // Iniciando animações do player
        if(body.velocity.x == 0 && body.velocity.y == 0 && onFloor == true )
        {
            anim.Play("Idle");
            //Inicia a animação dela parada
        }
        else if(body.velocity.x != 0 && onFloor == true)
        {
            anim.Play("Walk");
            //Inicia a animação dela correndo 
        }else if(body.velocity.y != 0 && body.velocity.x != 0) 
        {
            anim.Play("Jump");
        }
        

    }
    void OnDrawGizmosSelected()

    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, radius);
        
    }

   
}

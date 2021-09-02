using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spike;
    

    
    
    public float spawnTime;
    

    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("addEnemy", spawnTime, spawnTime);
        

        
    }

    

    void addEnemy()
    {
        // Variável para armazenar a posição X do objeto spawn.
        Renderer renderer = GetComponent<Renderer>();
        var x1 = transform.position.x - renderer.bounds.size.x / 2;
        var x2 = transform.position.x + renderer.bounds.size.x / 2;
        // Aleatoriamente escolhe um ponto dentro do objeto spawn
        var spawnPoint = new Vector2(transform.position.x, transform.position.y);
        // Criar um Asteroide na posição 'spawnPoint'
        Instantiate(spike, spawnPoint, Quaternion.identity);
    }

    

}

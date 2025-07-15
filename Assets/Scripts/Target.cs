using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    
    private GameManager gameManager;
    private float spawnPosX = 7;
    private float spawnPosY = 10;
    public int pointValue;
    


    // Start is called before the first frame update
    void Start()
    {
        
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
       
        transform.position = RandomSpawnPos();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-spawnPosX, spawnPosX), spawnPosY);
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (!gameObject.CompareTag("Bad"))
        {
           
            gameManager.GameOver();
            Destroy(gameObject);


        }
    }
    private void OnCollisionEnter(Collision collision)
    {   
       
            if(gameManager.isGameActive)
            {
               if (collision.gameObject.CompareTag("Player"))
               {

                 Destroy(gameObject);
                 gameManager.UpdateScore(pointValue);
                 

               }

            }


    }
    
   


}

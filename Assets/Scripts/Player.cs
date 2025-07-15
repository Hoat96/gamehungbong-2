using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    float xDirection;
    public float xRange = 10f;
    public AudioClip CrashSound;
    public AudioClip CrashSound2;
    private AudioSource playerAudio;
    private GameManager gameManager;
    
    
   
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerAudio= GetComponent<AudioSource>(); 
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {   
       
            if (gameManager.isGameActive == true)
            {
              if (transform.position.x < -xRange)
              {
                transform.position = new Vector3(-xRange, transform.position.y);
              }
              if (transform.position.x > xRange)
              {
                transform.position = new Vector3(xRange, transform.position.y);
              }
              xDirection = Input.GetAxisRaw("Horizontal");

              float moveStep = moveSpeed * Time.deltaTime * xDirection;

              transform.position = transform.position + new Vector3(moveStep, 0, 0);
            }
       
        
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerAudio.PlayOneShot(CrashSound, 1.0f);
        }
        if (collision.gameObject.CompareTag("Bad"))
        {
            playerAudio.PlayOneShot(CrashSound2, 2.0f);
        }
    }
    
}

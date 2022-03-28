using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ladder : MonoBehaviour
{
	[SerializeField] float coolDown;
    [SerializeField] float timer;
    [SerializeField] float speed = 5;
    private Vector2 PlayerVelocity;
    public Player Player;

    void Start()
    {
        this.gameObject.GetComponent<AudioSource>().enabled = false;
    }
    void Update()
    {
        PlayerVelocity = Player.GetComponent<Rigidbody2D>().velocity;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && PlayerVelocity != new Vector2(0, 0))
        {
            Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            Player.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D other) 
    {
        if (other.gameObject.GetComponent<SpriteRenderer>().sprite.name == "Box")
        {
            other.GetComponent<SpriteRenderer>().sortingOrder = 14;
        }
        
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                if (PlayerVelocity != new Vector2(0, 0))
                {
                    Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                }
                if (!this.gameObject.GetComponent<AudioSource>().enabled)
                this.gameObject.GetComponent<AudioSource>().enabled = true;
            }
            else
            {
                this.gameObject.GetComponent<AudioSource>().enabled = false;
            }
            other.GetComponent<Rigidbody2D>().gravityScale = 0;
            if (Input.GetKey(KeyCode.W))
            {
                
                other.GetComponent<SpriteRenderer>().sortingOrder = 14;
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                other.GetComponent<SpriteRenderer>().sortingOrder = 14;
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
            }
            else if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.D)))
            {			
                if (timer > 0)
                {
                    timer -= Time.deltaTime;
                }
                if (timer <= 0){
                    other.GetComponent<Rigidbody2D>().gravityScale = 3;
                    timer = coolDown;
                }
            }
        }
    }

     void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            other.GetComponent<SpriteRenderer>().sortingOrder = 50;
            this.gameObject.GetComponent<AudioSource>().enabled = false;
        }
        other.GetComponent<Rigidbody2D>().gravityScale = 3;
    }
}


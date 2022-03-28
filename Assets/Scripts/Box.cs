using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Player player;
    private bool box_status;
    private float flip;
    private Vector3 position;

    void Start()
    {
        flip = 1f;
        box_status = false;
    }
    void FixedUpdate()
    {
        if (box_status == true)
        {
            position = player.transform.position;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            if (Input.GetKey(KeyCode.D))
            {
                position.x = player.transform.position.x + 3f;
                flip = 1f;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                position.x = player.transform.position.x - 3f;
                flip = -1f;
            }

            position.x = player.transform.position.x + flip * 3f;
            this.transform.position = Vector3.Lerp(this.transform.position, position, 100f * Time.deltaTime);
        } else
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && box_status == false && player.itemInHands == false)
        {
            box_status = true;
            player.itemInHands = true;

        }
        else if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && box_status == true && player.itemInHands == true)
        {
            box_status = false;
            player.itemInHands = false;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 3;
        }
    }
}
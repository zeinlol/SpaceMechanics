using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flappy_Bird : MonoBehaviour
{
    private float speedX = 0.040f;
    private float speedY = 0.2f;
    public Vector2 Key_StartPosition;
    public BoxCollider2D[] flaps;
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        if (this.GetComponent<Rigidbody2D>().IsTouching(flaps[0]) || this.GetComponent<Rigidbody2D>().IsTouching(flaps[1]) || this.GetComponent<Rigidbody2D>().IsTouching(flaps[2]) || this.GetComponent<Rigidbody2D>().IsTouching(flaps[3]) || this.GetComponent<Rigidbody2D>().IsTouching(flaps[4]) || this.GetComponent<Rigidbody2D>().IsTouching(flaps[5]) || this.GetComponent<Rigidbody2D>().IsTouching(flaps[6]) || this.GetComponent<Rigidbody2D>().IsTouching(flaps[7]))
        {
            this.transform.position = Key_StartPosition;
        }
        this.transform.Translate(speedX, 0, 0);
        if (this.transform.position.y > 96f)
        {
            this.transform.position = new Vector2(this.transform.position.x, 8.06f);
        }
        else if (this.transform.position.y < 76.15f)
        {
            this.transform.position = new Vector2(this.transform.position.x, -14.27f);
        }
        if (this.transform.position.x > -52f)
        {
            this.transform.position = Key_StartPosition;
        }
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + speedY);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - speedY);
        }

    }
}

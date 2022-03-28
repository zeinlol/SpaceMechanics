using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float speedX;
    private float horizontalSpeed;
    private float verticalImpulse;
    private Transform transform_Player;
    private SpriteRenderer spriteRenderer_Player;
    private Rigidbody2D rigidbody2D_Player;
    private bool player_InAir;
    public bool itemInHands { get; set; }
    void Start()
    {
        transform_Player = GetComponent<Transform>();
        spriteRenderer_Player = GetComponent<SpriteRenderer>();
        rigidbody2D_Player = GetComponent<Rigidbody2D>();
        horizontalSpeed = 0.2f;
        verticalImpulse = 12;
        player_InAir = false;
        itemInHands = false;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && player_InAir == false)
        {
            player_InAir = true;
            rigidbody2D_Player.AddForce(new Vector2(0, verticalImpulse), ForceMode2D.Impulse);
        }
    }
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.A))
        {
            if (spriteRenderer_Player.flipX == true)
            {
                spriteRenderer_Player.flipX = !spriteRenderer_Player.flipX;
            }
            speedX = horizontalSpeed;
            transform_Player.Translate(speedX, 0, 0);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (spriteRenderer_Player.flipX == false)
            {
                spriteRenderer_Player.flipX = !spriteRenderer_Player.flipX;
            }
            speedX = -horizontalSpeed;
            transform_Player.Translate(speedX, 0, 0);
        }
        speedX = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            player_InAir = false;
        }
    }
}

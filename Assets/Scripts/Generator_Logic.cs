using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator_Logic : MonoBehaviour
{
    public GameObject[] collider_Objects;
    public Player player;
    public GameObject rails;
    public GameObject elevator_doors;
    public GameObject Camera;
    private bool check;
    private bool connector_connection;
    void Start()
    {
        check = false;
        connector_connection = false;
    }
    void FixedUpdate()
    {
        this.GetComponent<SpriteRenderer>().sortingOrder = -10;
       if(this.gameObject.GetComponent<AudioSource>().time >= 6f)
        {
            this.gameObject.GetComponent<AudioSource>().Stop();
        }
        if (collider_Objects[0].activeSelf == false && collider_Objects[1].activeSelf == false && collider_Objects[2].activeSelf == false && check == false)
        {
            Vector3 newPos = new Vector3(60.53f, -35f, 0);
            Vector3 newCamPos = new Vector3(32.4f, -31.2f, -38.76f);
            player.transform.position = newPos;
            player.gameObject.GetComponent<Player>().enabled = false;
            Camera.gameObject.GetComponent<camera_moove>().enabled = false;
            Camera.transform.position = newCamPos;
            Camera.gameObject.GetComponent<Camera>().fieldOfView = 30;
            collider_Objects[3].GetComponent<BoxCollider2D>().enabled = false;
            this.gameObject.GetComponent<Rigidbody2D>().simulated = true;
            this.gameObject.GetComponent<AudioSource>().Play();
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.5f, 0), ForceMode2D.Impulse);
            rails.GetComponent<BoxCollider2D>().isTrigger = false;
            check = true;
        }
        if (connector_connection == false && check == true)
        {
            InvokeRepeating("Generator_slide", 0, 3);
        }
    }
    private void Generator_slide()
    {
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.2f, 0), ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "connector_2" && connector_connection == false)
        {
            collider_Objects[3].GetComponent<BoxCollider2D>().enabled = true;
            this.gameObject.GetComponent<Rigidbody2D>().simulated = false;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rails.GetComponent<BoxCollider2D>().isTrigger = true;
            player.gameObject.GetComponent<Player>().enabled = true;
            Camera.gameObject.GetComponent<camera_moove>().enabled = true;
            Camera.gameObject.GetComponent<Camera>().fieldOfView = 20;
            elevator_doors.GetComponent<Door_Object>().door_spriteRenderer[0].sprite = elevator_doors.GetComponent<Door_Object>().spriteDoorOpen[0];
            elevator_doors.GetComponent<Door_Object>().door_spriteRenderer[1].sprite = elevator_doors.GetComponent<Door_Object>().spriteDoorOpen[1];
            elevator_doors.GetComponent<Door_Object>().door_BoxCollider.enabled = false;
            connector_connection = true;
        }
    }
}
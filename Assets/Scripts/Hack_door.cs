using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hack_door : MonoBehaviour
{
    public GameObject platform;
    public GameObject HackedMachine;
    public GameObject Camera;
    public Door_Object door_Object;
    public Player player;
    public Trigger EndTrigger;
    public Vector3 ActionScenePosition;

    void Start()
    {
        HackedMachine.SetActive(false);
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.gameObject.GetComponent<Hack_door>().enabled = true;
    }

    void FixedUpdate()
    {
        if (platform.GetComponent<SpriteRenderer>().sprite.name == "platform_pressed")
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
            this.GetComponent<BoxCollider2D>().enabled = true;
        }
        if (EndTrigger.ObjectInTrigger)
        {
            Camera.transform.position = player.transform.position;
            Invoke("BackToGame", 0.5f);
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            HackedMachine.SetActive(true);
            player.gameObject.GetComponent<Player>().enabled = false;
            Camera.gameObject.GetComponent<camera_moove>().enabled = false;
            Camera.transform.position = ActionScenePosition;
        }
    }
    void BackToGame()
    {
        HackedMachine.SetActive(false);
        player.gameObject.GetComponent<Player>().enabled = true;
        Camera.gameObject.GetComponent<camera_moove>().enabled = true;
        door_Object.Door_Change();
        this.gameObject.GetComponent<Hack_door>().enabled = false;
    }
}

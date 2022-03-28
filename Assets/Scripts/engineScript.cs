using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class engineScript : MonoBehaviour
{
    public GameObject Engine_Level;
    public GameObject Camera;
    public Trigger[] gears = new Trigger[4];
    public Player player;

    [System.Obsolete]
    void Start()
    {
        this.gameObject.GetComponent<AudioSource>().enabled = false;
    }
    void FixedUpdate()
    {
       /* if (gears[0].ObjectInTrigger)
        {
        }*/
        if (gears[0].ObjectInTrigger && gears[1].ObjectInTrigger && gears[2].ObjectInTrigger && gears[3].ObjectInTrigger)
        {
            Camera.transform.position = player.transform.position;
            Invoke("BacktToGame", 0.5f);
        }
    }

    [System.Obsolete]
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            Engine_Level.SetActive(true);
            Vector3 newCamPos = new Vector3(-80.74f, 155.6f, -57f);
            player.gameObject.GetComponent<Player>().enabled = false;
            Camera.gameObject.GetComponent<camera_moove>().enabled = false;
            Camera.transform.position = newCamPos;
        }
    }
    void BacktToGame()
    {
        Engine_Level.SetActive(false);
        player.gameObject.GetComponent<Player>().enabled = true;
        Camera.gameObject.GetComponent<camera_moove>().enabled = true;
        this.gameObject.GetComponent<AudioSource>().enabled = true;
        this.gameObject.GetComponent<engineScript>().enabled = false;
    }
}

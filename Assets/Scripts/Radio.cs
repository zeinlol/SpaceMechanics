using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    public GameObject Radio_Level;
    public GameObject Camera;
    public Trigger[] gears = new Trigger[4];
    public Player player;
    void FixedUpdate()
    {
        if (gears[0].ObjectInTrigger && gears[1].ObjectInTrigger && gears[2].ObjectInTrigger && gears[3].ObjectInTrigger)
        {
            //Camera.transform.position = player.transform.position;
            Invoke("EndGame", 0.5f);
        }
    }

    [System.Obsolete]
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            Radio_Level.SetActive(true);
            Vector3 newCamPos = new Vector3(-171f, 87.16f, -57f);
            player.gameObject.GetComponent<Player>().enabled = false;
            Camera.gameObject.GetComponent<camera_moove>().enabled = false;
            Camera.transform.position = newCamPos;
        }
    }

    /*void BacktToGame()
    {
        player.gameObject.GetComponent<Player>().enabled = true;
        Camera.gameObject.GetComponent<camera_moove>().enabled = true;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Invoke("EndGame", 1f);
        //gameObject.SetActive(false);
    }*/
    //[System.Obsolete]
    void EndGame()
    {
        Application.LoadLevel("EndGame");
    }
}

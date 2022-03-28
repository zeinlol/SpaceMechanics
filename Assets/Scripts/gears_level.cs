using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gears_level : MonoBehaviour
{
    public GameObject Gears_Level;
    public GameObject Gears_anim;
    public GameObject Robot;
    public GameObject Camera;
    public GameObject Junk;
    public Trigger[] gears = new Trigger[4];
    public Player player;

    [System.Obsolete]
    void Start()
    {
        Junk.SetActive(false);
        Gears_anim.GetComponent<Animator>().enabled = false;
        this.gameObject.GetComponent<AudioSource>().enabled = false;
        Robot.active = false;
    }
    void FixedUpdate()
    {
        if (gears[0].ObjectInTrigger && gears[1].ObjectInTrigger && gears[2].ObjectInTrigger && gears[3].ObjectInTrigger)
        {
            Camera.transform.position = player.transform.position;
            Junk.SetActive(true);
            Invoke("BacktToGame", 0.5f);
        }
    }

    [System.Obsolete]
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            Gears_Level.SetActive(true);
            Vector3 newCamPos = new Vector3(32.4f, 103.9f, -57f);
            player.gameObject.GetComponent<Player>().enabled = false;
            Camera.gameObject.GetComponent<camera_moove>().enabled = false;
            Camera.transform.position = newCamPos;
        }
    }
    void BacktToGame ()
    {
        Gears_Level.SetActive(false);
        player.gameObject.GetComponent<Player>().enabled = true;
        Camera.gameObject.GetComponent<camera_moove>().enabled = true;
        this.gameObject.GetComponent<AudioSource>().enabled = true;
        Gears_anim.GetComponent<Animator>().enabled = true;
        Robot.active = true;
        this.gameObject.GetComponent<gears_level>().enabled = false;
    }
}

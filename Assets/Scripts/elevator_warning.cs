using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator_warning : MonoBehaviour
{
    public GameObject Doors;
    void OnTriggerEnter2D(Collider2D other)
    {
            if (Doors.gameObject.GetComponent<BoxCollider2D>().enabled)
            {
                if (!this.GetComponent<AudioSource>().isPlaying) 
                {
                this.gameObject.GetComponent<AudioSource>().Play();
                }
            } else
                {
                    this.gameObject.GetComponent<AudioSource>().enabled = false;
                }
    }
}

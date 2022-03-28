using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{

    public bool ObjectInTrigger { get; set; }

    void Start()
    {
        ObjectInTrigger = false;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("gear_target") && Input.GetMouseButtonUp(0))
        {
            other.gameObject.GetComponent<AudioSource>().enabled = true;
            other.transform.position = this.transform.position;
            ObjectInTrigger = true;
            other.gameObject.GetComponent<Mouse_MovingObj>().enabled = false;
        }
        /*else if (other.CompareTag("Key"))
        {
            other.gameObject.GetComponent<AudioSource>().enabled = true;
            ObjectInTrigger = true;
        }*/
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Key"))
        {
            other.gameObject.GetComponent<AudioSource>().enabled = true;
            ObjectInTrigger = true;
        }
    }
}

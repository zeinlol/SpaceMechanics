using System.Collections;
using System.Collections.Generic;
  

using UnityEngine;

[System.Runtime.InteropServices.ComVisible(true)]

public class Sounds : MonoBehaviour
{
    public AudioClip no_way1;
    public AudioClip no_way2;
    public AudioClip no_way3;
    AudioSource audio;
    public bool hasPlayed = false;
    public int rand;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasPlayed)
        {
            if (other.tag == "Player")
            {
                rand = Random.Range(0, 3);
                if (rand == 0)
                {
                    audio.PlayOneShot(no_way1);
                    hasPlayed = true;
                }
                else if (rand == 1)
                {
                    audio.PlayOneShot(no_way2);
                    hasPlayed = true;
                }
                else if (rand == 2)
                {
                    audio.PlayOneShot(no_way3);
                    hasPlayed = true;
                }


            }
        }

    }
}
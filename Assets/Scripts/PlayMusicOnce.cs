using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicOnce : MonoBehaviour
{
    private bool Played;
    void Start()
    {
        Played = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!this.GetComponent<AudioSource>().isPlaying && !Played && other.CompareTag("Player"))
        {
            this.gameObject.GetComponent<AudioSource>().enabled = true;
            Played = true;
        }
    }
}

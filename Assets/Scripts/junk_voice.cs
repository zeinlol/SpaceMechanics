﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class junk_voice : MonoBehaviour
{
    public Player player;
    
    void OnTriggerEnter2D( Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.gameObject.GetComponent<AudioSource>().Play();
        }
    }
}

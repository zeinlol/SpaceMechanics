﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class respawner : MonoBehaviour
{
    public GameObject respawn;
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                SceneManager.LoadScene("main");
            }
        }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}

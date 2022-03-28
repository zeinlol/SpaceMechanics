using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour
{
    private bool computer_status;
    public Sprite switchSprite;
    public AudioClip first_powerON;
    AudioSource audio;
    public bool hasPlayed=false;
    public void UpdateComputer(bool status)
    {
        computer_status = status;
    }

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (
            (Input.GetKey(KeyCode.E)) && computer_status == true)

        {


            this.GetComponent<SpriteRenderer>().sprite = switchSprite;
            if (!hasPlayed)
            {
                hasPlayed = true;
                audio.PlayOneShot(first_powerON);
            }
        }
    }
}
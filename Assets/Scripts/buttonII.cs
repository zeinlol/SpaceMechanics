using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonII : MonoBehaviour
{
    // Start is called before the first frame update
    private PC computer;

    private void Awake()
    {
        computer =PC.FindObjectOfType<PC>();
    }




  private bool status;
    public Sprite switchSprite;

    public void UpdateButton(bool CableStatus)
    {
        status = CableStatus;
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if ((Input.GetKey(KeyCode.E)) && status==true)
        {  computer.UpdateComputer(status);
            this.gameObject.GetComponent<AudioSource>().Play();
            this.GetComponent<SpriteRenderer>().sprite = switchSprite;
        }


    }
}
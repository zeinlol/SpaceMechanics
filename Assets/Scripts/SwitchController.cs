using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{ 
    public Sprite switchOnSprite;
    public bool CableStatus = false;
    private buttonII _button;

    private void Awake()
    {
        _button = buttonII.FindObjectOfType<buttonII>();
    }


    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                this.gameObject.GetComponent<AudioSource>().Play();
                CableStatus = true;
                this.GetComponent<SpriteRenderer>().sprite = switchOnSprite;
                _button.UpdateButton(CableStatus);
            }
        }
    }
}

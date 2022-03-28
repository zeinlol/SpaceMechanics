using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_button : MonoBehaviour
{
    public GameObject target_Object;
    public Sprite button_SpriteOn;
    private bool Trigger_Action { get; set; }
    private Sprite button_SpriteOff;
    private SpriteRenderer button_spriteRenderer;
    private float current_time;
    void Start()
    {
        Trigger_Action = false;
        button_spriteRenderer = GetComponent<SpriteRenderer>();
        button_SpriteOff = button_spriteRenderer.sprite;
        target_Object.GetComponent<BoxCollider2D>().enabled = false;
        target_Object.GetComponent<ElevatorMoving>().enabled = false;
        target_Object.GetComponent<AudioSource>().enabled = false;
    }
    void Update()
    {
        if (current_time > 0 && Trigger_Action == true)
        {
            current_time -= Time.deltaTime;
        }
        else if (current_time <= 0 && Trigger_Action == true)
        {
            
            button_spriteRenderer.sprite = button_SpriteOff;
            current_time = 0;
            Trigger_Action = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && (Input.GetKeyUp(KeyCode.E) && Trigger_Action == false))
        {
            this.gameObject.GetComponent<AudioSource>().Play();
            button_spriteRenderer.sprite = button_SpriteOn;
            current_time = 2f;
            target_Object.GetComponent<AudioSource>().enabled = true;
            target_Object.GetComponent<ElevatorMoving>().enabled = true;
            target_Object.GetComponent<BoxCollider2D>().enabled = true;
            Trigger_Action = true;
        }
    }
}


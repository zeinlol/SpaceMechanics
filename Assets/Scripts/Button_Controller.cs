using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Button_Controller : MonoBehaviour
{
    public Door_Object door_Object;
    public GameObject target_Object;
    public Sprite button_SpriteOn;
    public GameObject filter;
    private Sprite button_SpriteOff;
    private SpriteRenderer button_spriteRenderer;
    public bool Trigger_Action { get; set; }
    private float current_time;
    
    void Start()
    {
        filter = GameObject.Find("filter");
        Trigger_Action = false;
        button_spriteRenderer = GetComponent<SpriteRenderer>();
        button_SpriteOff = button_spriteRenderer.sprite;
    }
    void Update()
    {
        if (current_time > 0 && Trigger_Action == true)
        {
            current_time -= Time.deltaTime;
        }
        else if (current_time <= 0 && Trigger_Action == true)
        {
            if (this.name == "firstroom_button")
            {
                door_Object.Door_Change();
            }
            button_spriteRenderer.sprite = button_SpriteOff;
            current_time = 0;
            Trigger_Action = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && this.name == "Respawn_Button" && (Input.GetKeyUp(KeyCode.E) && Trigger_Action == false))
        {
            this.gameObject.GetComponent<AudioSource>().Play();
            filter.SetActive(false);
            door_Object.Door_Change();
            button_spriteRenderer.sprite = button_SpriteOn;
            current_time = 2f;
            Trigger_Action = true;
        }
        else if (collision.gameObject.name == "Player" && this.name == "subRoom_button" && (Input.GetKeyUp(KeyCode.E) && Trigger_Action == false)){
            this.gameObject.GetComponent<AudioSource>().Play();
            button_spriteRenderer.sprite = button_SpriteOn;
            current_time = 1f;
            Trigger_Action = true;
        }
        else if (collision.gameObject.name == "Player" && this.CompareTag("wall_buttons") && (Input.GetKeyUp(KeyCode.E) && Trigger_Action == false)){
            this.gameObject.GetComponent<AudioSource>().Play();
            target_Object.SetActive(false);
            button_spriteRenderer.sprite = button_SpriteOn;
            current_time = 2f;
            Trigger_Action = true;
        }
    }
}


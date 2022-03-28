using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider_Controller : MonoBehaviour
{
    public GameObject target_Object;
    public bool Trigger_Action { get; set; }
    private Sprite slider_SpriteOff;
    public Sprite slider_ChangeSprite;
    private SpriteRenderer slider_spriteRenderer;
    private float current_time;
    void Start()
    {
        if(this.name == "first smallroom SliderOff")
        {
            Trigger_Action = false;
        }
        else if (this.name == "second smallroom SliderOn")
        {
            Trigger_Action = true;
        }
        slider_spriteRenderer = GetComponent<SpriteRenderer>();
        slider_SpriteOff = slider_spriteRenderer.sprite;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && this.name == "subRoom_ SliderOff" && Input.GetKeyUp(KeyCode.E))
        {
            this.gameObject.GetComponent<AudioSource>().Play();
            if (slider_spriteRenderer.sprite == slider_ChangeSprite)
            {
                slider_spriteRenderer.sprite = slider_SpriteOff;
            }
            else
            {
                slider_spriteRenderer.sprite = slider_ChangeSprite;
            }
            
            if (Trigger_Action == true)
            {
                Trigger_Action = false;
            }
            else
            {
                Trigger_Action = true;
            }
        }
        else if (collision.gameObject.name == "Player" && this.name == "subRoom_SliderOn" && Input.GetKeyUp(KeyCode.E))
        {
            this.gameObject.GetComponent<AudioSource>().Play();
            if (slider_spriteRenderer.sprite == slider_ChangeSprite)
            {
                slider_spriteRenderer.sprite = slider_SpriteOff;
            }
            else
            {
                slider_spriteRenderer.sprite = slider_ChangeSprite;
            }
            if (Trigger_Action == true)
            {
                Trigger_Action = false;
            }
            else
            {
                Trigger_Action = true;
            }
        }
        else if (collision.gameObject.name == "Player" && this.name == "generator_SliderOff" && Input.GetKeyUp(KeyCode.E))
        {
            this.gameObject.GetComponent<AudioSource>().Play();
            if (slider_spriteRenderer.sprite == slider_ChangeSprite)
            {
                slider_spriteRenderer.sprite = slider_SpriteOff;
            }
            else
            {
                slider_spriteRenderer.sprite = slider_ChangeSprite;
            }
            if (Trigger_Action == true)
            {
                Trigger_Action = false;
            }
            else
            {
                Trigger_Action = true;
            }
            target_Object.SetActive(false);
        }
    }
}

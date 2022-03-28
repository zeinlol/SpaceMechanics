using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Plate_Controller : MonoBehaviour
{
    public GameObject[] target_Object;
    public Sprite plate_spriteOnSprite;
    private Sprite plate_spriteOffSprite;
    private SpriteRenderer plate_spriteRenderer;
    private BoxCollider2D plate_BoxCollider;
    private float current_time;
    private bool playMusic;
    public bool ObjectOnPlate { get; set; }
    public bool PlayerOnPlate { get; set; }
    void Start()
    {
        ObjectOnPlate = false;
        PlayerOnPlate = false;
        playMusic = true;
        plate_spriteRenderer = GetComponent<SpriteRenderer>();
        plate_BoxCollider = GetComponent<BoxCollider2D>();
        plate_spriteOffSprite = plate_spriteRenderer.sprite;
    }
    void Update()
    {
        if (current_time > 0 && ObjectOnPlate == false && PlayerOnPlate == false)
        {
            current_time -= Time.deltaTime;
        }
        else if (current_time <= 0 && ObjectOnPlate == false && PlayerOnPlate == false)
        {
            plate_spriteRenderer.sprite = plate_spriteOffSprite;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.name == "Player" && this.name == "generator_platform")
        {
            target_Object[0].SetActive(true);
            target_Object[1].SetActive(true);
            target_Object[2].SetActive(true);
            plate_spriteRenderer.sprite = plate_spriteOnSprite;
            current_time = 1f;
            PlayerOnPlate = true;
            if (playMusic)
            {
                this.gameObject.GetComponent<AudioSource>().Play();
            }
        }
        else if (collision.gameObject.name == "Player")
        {
            plate_spriteRenderer.sprite = plate_spriteOnSprite;
            current_time = 1f;
            PlayerOnPlate = true;
            if (playMusic)
            {
                this.gameObject.GetComponent<AudioSource>().Play();
            }
        }
        else if (collision.gameObject.GetComponent<SpriteRenderer>().sprite.name == "Box" || collision.gameObject.GetComponent<BoxCollider2D>().enabled)
        {
            plate_spriteRenderer.sprite = plate_spriteOnSprite;
            current_time = 1f;
            ObjectOnPlate = true;
            if (playMusic)
            {
                this.gameObject.GetComponent<AudioSource>().Play();
            }
            playMusic = false;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayerOnPlate = false;
        }
        else if (collision.gameObject.GetComponent<SpriteRenderer>().sprite.name == "Box")
        {

            ObjectOnPlate = false;
            this.gameObject.GetComponent<AudioSource>().Play();
            playMusic = true;
        }
    }
}


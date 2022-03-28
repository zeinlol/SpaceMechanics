using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Object : MonoBehaviour
{
    public Sprite[] spriteDoorClosed { get; set; }
    public Sprite[] spriteDoorOpen;
    public SpriteRenderer[] door_spriteRenderer { get; set; }
    public BoxCollider2D door_BoxCollider { get; set; }
    public bool door_Status { get; set; }
    void Start()
    {
        door_Status = false;
        spriteDoorClosed = new Sprite[2];
        door_spriteRenderer = this.GetComponentsInChildren<SpriteRenderer>();
        spriteDoorClosed[0] = door_spriteRenderer[0].sprite;
        spriteDoorClosed[1] = door_spriteRenderer[1].sprite;
        door_BoxCollider = this.transform.GetChild(1).GetComponent<BoxCollider2D>();
    }
    public void Door_Change()
    {
        if(door_Status == false)
        {

            this.gameObject.GetComponent<AudioSource>().Play();
            door_spriteRenderer[0].sprite = spriteDoorOpen[0];
            door_spriteRenderer[1].sprite = spriteDoorOpen[1];
            door_BoxCollider.enabled = false;
            door_spriteRenderer[1].sortingOrder = 56;
            Invoke("DoorDestroy", 15.0f);
        }
        else if (door_Status == true)
        {
            door_spriteRenderer[0].sprite = spriteDoorClosed[0];
            door_spriteRenderer[1].sprite = spriteDoorClosed[1];
            door_BoxCollider.enabled = true;
        }
        if (door_BoxCollider.enabled == false)
        {
            this.gameObject.GetComponent<AudioSource>().enabled = false;
        }
    }
    public void DoorDestroy()
    {
        door_spriteRenderer[1].GetComponent<SpriteRenderer>().enabled = false;
    }

}

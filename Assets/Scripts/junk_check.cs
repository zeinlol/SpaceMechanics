using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class junk_check : MonoBehaviour
{
    //public static List<GameObject> BoxInTrigger = new List<GameObject>();
    public GameObject WallMove;
    public GameObject Robot;
    private float NumberBoxes;
    private bool BoxInTrigger;
    public GameObject Box;
    Vector3 endPos;
    void Start()
    {
        Box.SetActive(true);
        BoxInTrigger = false;
        endPos = new Vector3(94.28f, 7f, 0f);
        //BoxInTrigger.Add(gameObject);
    }
    void FixedUpdate()
    {
        Debug.Log("Boxes: " + NumberBoxes);
        if (NumberBoxes <= 0 && BoxInTrigger == true)
        {
            WallMove.transform.position = endPos;
            this.gameObject.GetComponent<AudioSource>().enabled = true;
            Robot.gameObject.GetComponent<AudioSource>().enabled = false;
            BoxInTrigger = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {
            BoxInTrigger = true;
            NumberBoxes++;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {
            NumberBoxes--;
        }
        /*if (other.gameObject.GetComponent<SpriteRenderer>().sprite.name == ("Box"))
        {
            NumberBoxes--;
        }*/
    }
    /*void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<SpriteRenderer>().sprite.name == ("Box"))
        {
            //NumberBoxes++;
            BoxInTrigger.Remove(other.gameObject);
        }
    }*/
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class junk_check : MonoBehaviour
{
    public static List<GameObject> BoxInTrigger = new List<GameObject>();
    public GameObject WallMove;
    public GameObject Robot;
    public float NumberBoxes;
    private bool free;
    Vector3 endPos;
    void Start()
    {
        free = false;
        endPos = new Vector3(94.28f, 7f, 0f);
        BoxInTrigger.Add(gameObject);
    }
    void Update()
    {
        Debug.Log("Boxes: " + NumberBoxes);
    }
    void FixedUpdate()
    {
        /*if (NumberBoxes <= 0)
        {
            free = true;
        }
        if (free)
        {            
            WallMove.transform.position = endPos;
            this.gameObject.GetComponent<AudioSource>().enabled = true;
            Robot.gameObject.GetComponent<AudioSource>().enabled = false;

        }*/
        
        if (/*BoxInTrigger.Count == 0*/ NumberBoxes <= 0)
        {
            free = true;
        } else
        {
            free = false;
        }
        if (free)
        {
            WallMove.transform.position = endPos;
            this.gameObject.GetComponent<AudioSource>().enabled = true;
            Robot.gameObject.GetComponent<AudioSource>().enabled = false;

        }
    }
    /*void OnTriggerEnter2D (Collider2D other)
    {
        BoxInTrigger.Add(other.gameObject);
    }*/
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour
{
    public GameObject exit1;
    /*public Vector2 startPosition;
    public Vector2 endPosition;
    public float speed;
    public float progress;
    public bool PlayerIn;*/
    public Transform Board;
    void Start()
    {
        //Board.position = startPosition;
        exit1.GetComponent<BoxCollider2D>().enabled = false;
        //PlayerIn = false;
    }
   /* void FixedUpdate()
    {
        if (PlayerIn)
        {
            Board.transform.position = Vector2.Lerp(startPosition, endPosition, progress);
            if (progress >= 1)
            {
                progress = 0;
            }
            progress += speed;
        }
    }*/
    void OnTriggerStay2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            exit1.GetComponent<BoxCollider2D>().enabled = true;
            //PlayerIn = true;
        }
    }
}

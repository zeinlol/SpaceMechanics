using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class schafa : MonoBehaviour
{
    private BoxCollider2D collider2D;
    public bool ActiveCollider;
    Rigidbody2D rigid;
    private void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();
        collider2D = this.GetComponent<BoxCollider2D>();
        collider2D.enabled = false;
        ActiveCollider = false;
        
    }
    void Update()
    {
        if (ActiveCollider)
        {
            collider2D.enabled = true;
            rigid.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        }
        else
        {
            collider2D.enabled = false;
            rigid.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyUp(KeyCode.E))
        {
            ActiveCollider = !ActiveCollider;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ActiveCollider = false;
            collider2D.enabled = false;
        }
    }
} 

               
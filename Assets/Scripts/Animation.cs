using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public Player player;
    public Animator anim;
    private bool control;
    //private bool MoveObj;
    public GameObject GasTrigger;
    public schafa[] schafa = new schafa[3];

    void Start() {
	    anim = GetComponent<Animator>();
        control = false;
        //MoveObj = false;
    }
    void Update()
    {
        /*if (MoveObj)
        {
            anim.SetBool("move", true);
        } else
        {
            anim.SetBool("move", false);
        }*/
        anim.SetBool("jump", false);
        if (schafa[0].GetComponent<schafa>().ActiveCollider || schafa[1].GetComponent<schafa>().ActiveCollider || schafa[2].GetComponent<schafa>().ActiveCollider)
        {
            anim.SetBool("move", true);
        }
        else
        {
            anim.SetBool("move", false);
        }
        if (GasTrigger.GetComponent<gas>().Timer <= 0)
        {
            control = true;
        }
        if (control)
        {
            DieAnim();
        } else
        {
            anim.SetBool("die", false);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (player.itemInHands)
            {
                anim.SetBool("box_walking", true);
                //anim.SetBool("box_iddle", false);
            } else
            {
                anim.SetBool("walking", true);
            }
	    } else 
        {
            if (player.itemInHands)
            {
                anim.SetBool("box_walking", false);
                anim.SetBool("box_iddle", true);
            } else
            {
                anim.SetBool("box_iddle", false);
                anim.SetBool("walking", false);
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("jump", true);
        }
    }
	void OnTriggerStay2D (Collider2D other) {
        if (other.gameObject.CompareTag("stairs"))
		{
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                anim.SetBool("walking", true);
            }
            else
            {
                anim.SetBool("walking", false);
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                anim.speed = 1f;
                anim.SetBool("ladder", true);
            }
            else if (anim.GetBool("ladder")) 
            {
                anim.speed = 0f;
            }
        }
        /*if (other.gameObject.CompareTag("control") && Input.GetKey(KeyCode.E))
        {
            MoveObj = !MoveObj;
        }*/
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("stairs"))
        {
        anim.speed = 1f;
        anim.SetBool("ladder", false);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                anim.SetBool("walking", true);
            }
            else
            {
                anim.SetBool("walking", false);
            }
        }
    }
    void DieAnim()
    {
        anim.SetBool("die", true);
        control = false;
    }
}

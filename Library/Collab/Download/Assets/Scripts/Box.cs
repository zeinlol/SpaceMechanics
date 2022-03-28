using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Transform player;
    public GameObject BoxObj;
    private bool active;
    private bool action;
    private float flip = -1f;
    private float current_time;
    Vector3 position;
    public Transform BoxPosition;
    Vector3 Boxposition;

    void Start()
    {
        current_time = 0;
        active = false;
        action = false;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        //this.gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }
    void Update()
    {
        if (current_time > 0 && action == true)
        {
            current_time -= Time.deltaTime;
        }
        else if (current_time <= 0 && action == true)
        {
            current_time = 0;
            action = false;
        }
    }
    void FixedUpdate()
    {
        if (active)
        {
            /*this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;*/
            position = player.position;
            BoxObj.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            BoxObj.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            if (Input.GetKey(KeyCode.D)) 
            {
                position.x = player.position.x + 3f;
                flip = 1;
            } else if(Input.GetKey(KeyCode.A))
            {
                position.x = player.position.x - 3f;
                flip = -1;
            }
            position.x = player.position.x + flip*3f;
            transform.position = Vector3.Lerp(transform.position, position, 100f * Time.deltaTime);
            BoxPosition.position = Vector3.Lerp(transform.position, position, 100f * Time.deltaTime);
        }
        else
        {
            /*this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 3;*/
            Boxposition = BoxPosition.position;
            BoxObj.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            BoxObj.gameObject.GetComponent<Rigidbody2D>().gravityScale = 3;
            Boxposition.z = -BoxPosition.position.z;
            transform.position = Vector3.Lerp(transform.position, Boxposition, 100f * Time.deltaTime);
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E) && action == false)
        {
            current_time = 2f;
            active = !active;
        }
    }
}
using UnityEngine;
using System.Collections;

public class ElevatorMoving : MonoBehaviour
{
    public bool Colliding = false;
    public Vector3 BasePosition;
    public Vector3 TargetPosition;
    public bool MoveAction;
    public float Move;
    public float speed;
    private bool Played = false;
    public Player Player;
    public Transform player;
    public Transform camera;
    public GameObject Elevator2;
    public GameObject ElevatorCollider;
    Vector3 position;

    void Start()
    {
        transform.position = BasePosition;
        Elevator2.GetComponent<SpriteRenderer>().enabled = false;
        ElevatorCollider.GetComponent<BoxCollider2D>().enabled = false;
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player") && !Colliding)
        {
            
            Colliding = true;
            MoveAction = true;
            BasePosition = transform.position;
        }
    }
    private void OnTriggerStay2D(Collider2D other)

    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            if (!Played)
            {
                this.gameObject.GetComponent<AudioSource>().Play();
                Played = true;
            }
        }
    }
    void OnTriggerExit2D (Collider2D other)
    {
        if (!Played)
        {
            Player.GetComponent<Rigidbody2D>().gravityScale = 3;
            gameObject.GetComponent<ElevatorMoving>().enabled = false;
        }
    } 
    void Update()
    {
        if (MoveAction && Move <= 1)
        {
            position = player.position;
            transform.position = Vector3.Lerp(BasePosition, TargetPosition, Move);
            position.y = transform.position.y -  5f;
            player.position = position;
            position.z = -38.76f;
            position.y = position.y + 2f;
            camera.position = position;
            Move += speed;
            ElevatorCollider.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            player.position = player.position;
            Player.GetComponent<Rigidbody2D>().gravityScale = 3;
            MoveAction = false;
            Elevator2.GetComponent<SpriteRenderer>().enabled = true;
            ElevatorCollider.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
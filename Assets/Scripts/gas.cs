using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gas : MonoBehaviour
{
    public Player Player;
    public float Timer;
    private float TimerTemp;
    public Vector2 RestartPossition;
    private bool TimerOn;
    void Start()
    {
        TimerTemp = Timer;
        TimerOn = false;
    }

    [System.Obsolete]
    void FixedUpdate()
    {
        if (TimerOn)
        {
            Timer -= Time.deltaTime;
        }
        if (Timer <= 0)
        {
            Invoke("Reload", 2f);
        }
    }
    void OntriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TimerOn = true;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TimerOn = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Timer = TimerTemp;
            TimerOn = false;
        }
    }
    void Reload ()
    {
        Player.transform.position = RestartPossition;
    }
}

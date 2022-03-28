using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud_moving : MonoBehaviour
{
    private SpriteRenderer spriteRenderer_Robot;
    public Vector2 startPosition;
    public Vector2 endPosition;
    public float speed;
    public float progress;

    void Start()
    {
        transform.position = startPosition;
        spriteRenderer_Robot = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        transform.position = Vector2.Lerp(endPosition, startPosition, progress);

        if (progress >= 1)
        {
            speed = -speed;
        }
        else if (progress < 0)
        {
            speed = -speed;
        }
        progress += speed;
    }
}



























using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comet : MonoBehaviour
{
    private SpriteRenderer spriteRenderer_comet;
    public Vector2 startPosition;
    public Vector2 endPosition;
    public float speed;
    public float progress;

    void Start()
    {
        transform.position = startPosition;
        spriteRenderer_comet = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        transform.position = Vector2.Lerp(endPosition, startPosition, progress);
        if (progress >= 1)
        {
            progress = 0;
        }
        progress += speed;
    }
}

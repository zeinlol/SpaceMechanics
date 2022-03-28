using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robot_moving : MonoBehaviour
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

    // Update is called once per frame
    void FixedUpdate()
    {
	transform.position = Vector2.Lerp(endPosition, startPosition, progress);

	if (progress >= 1) {
if (spriteRenderer_Robot.flipX){
		spriteRenderer_Robot.flipX = !spriteRenderer_Robot.flipX;}
		speed = -speed;
		
	} else if (progress < 0) {
if (!spriteRenderer_Robot.flipX){
		spriteRenderer_Robot.flipX = !spriteRenderer_Robot.flipX;}
speed = -speed;
} 
	progress += speed;
    }
}



























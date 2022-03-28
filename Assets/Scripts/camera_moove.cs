using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_moove : MonoBehaviour
{

    public Transform who;
    Vector3 position;

    void Start()
    {
        transform.position = who.position;
        position.y = position.y + 2.15f;
    }
    void FixedUpdate()
    {
        position = who.position;
        position.z = -38.76f;
        position.y = who.position.y + 2.15f;
        transform.position = Vector3.Lerp(transform.position, position, 3f * Time.deltaTime);
    }
}

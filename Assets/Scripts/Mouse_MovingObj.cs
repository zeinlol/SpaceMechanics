using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_MovingObj : MonoBehaviour
{
    private Vector3 offset;
    public Camera curCam;
    void OnMouseDown()
    {
            Vector3 temp_V = Input.mousePosition;
            temp_V.z = 57f;
            offset = this.transform.position - curCam.ScreenToWorldPoint(temp_V);
    }
    void OnMouseDrag()
    {
        Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 57f);
        this.transform.position = (curCam.ScreenToWorldPoint(newPosition) + offset);
    }
}

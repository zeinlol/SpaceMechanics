using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_enable : MonoBehaviour
{
    [System.Obsolete]
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.LoadLevel("menu");
        }
    }
}
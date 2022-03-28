using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldingBox : MonoBehaviour
{ public Image myImageComponent; // Image component attached to this gameobject
 
    public Sprite originalSprite;
    public Sprite pressedSprite;
 
 
    void Start() //Lets start by getting a reference to our image component.
    {
        myImageComponent = GetComponent<Image>();
    }
 
    void Update()
    {
        if(Input.GetKey(KeyCode.F))
        {
            myImageComponent.sprite  = pressedSprite;
        }
        else if(Input.GetKeyUp(KeyCode.F))
        {
            myImageComponent.sprite = originalSprite;
        }
    }
}
    
 
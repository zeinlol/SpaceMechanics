using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class elevatorRoom_Logic : MonoBehaviour
{
    public Door_Object closed_doors_3lvl;
    public Plate_Controller[] plates = new Plate_Controller[3];
    private float show_Triggers;
    //private bool[] Audio_Trigger;
    //private Transform[] Fail_Sound;

    void Start()
    {
        //Fail_Sound = new Transform[2];
        //Audio_Trigger = new bool[2] { false, false };
    }
    void FixedUpdate()
    {
        //if (show_Triggers <= 0 && Audio_Trigger[0] == true)
        /*if (show_Triggers <= 0)
        {
            SceneManager.LoadScene("main");
        }*/
        if (plates[0].ObjectOnPlate == true && plates[1].ObjectOnPlate == true && plates[2].ObjectOnPlate == true)
        {
            closed_doors_3lvl.Door_Change();
        }
        //show_Triggers -= Time.deltaTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondRoom_Logic : MonoBehaviour
{
    public Door_Object secondroom_Doors;
    public Plate_Controller[] plates = new Plate_Controller[2];
    public Slider_Controller[] sliders = new Slider_Controller[2];
    public Button_Controller wall_button;
    private float show_Triggers;
    private bool Destroy_Trigger;
    private bool[] Audio_Trigger;
    private Transform[] Fail_Sound;
    void Start()
    {
        Fail_Sound = new Transform[2];
        Destroy_Trigger = false;
        Audio_Trigger = new bool[2] { false, false };
    }
    void FixedUpdate()
    {
        if (show_Triggers <= 0 && Audio_Trigger[0] == true)
        {
            SceneManager.LoadScene("main");
        }
        if (plates[0].ObjectOnPlate == true && plates[1].ObjectOnPlate == true && sliders[0].Trigger_Action == false && sliders[1].Trigger_Action == true && wall_button.Trigger_Action == false) {
            secondroom_Doors.Door_Change();
        }
        else if (plates[0].ObjectOnPlate == false && sliders[0].Trigger_Action == true && sliders[1].Trigger_Action == false && wall_button.Trigger_Action == true && plates[1].ObjectOnPlate == false && (Audio_Trigger[0] == false && Audio_Trigger[1] == false))
        {
            Destroy_Trigger = true;
        }
        if(Destroy_Trigger == true)
        {
            Destroy();
        }
        show_Triggers -= Time.deltaTime;
    }
    public void Destroy()
    {
        if (show_Triggers <= 0)
        {
            Fail_Sound[0] = GameObject.Find("DestroyShip_Audio").transform.GetChild(0);
            Fail_Sound[0].gameObject.GetComponent<AudioSource>().PlayOneShot(Fail_Sound[0].gameObject.GetComponent<AudioSource>().clip);
            show_Triggers = 12f;
        }
        else if ((show_Triggers - Time.deltaTime) <= 0)
        {
            Destroy_Trigger = false;
            int random = 0 /*Random.Range(0, 2)*/;
            if (random == 0)
            {
                Fail_Sound[0] = GameObject.Find("DestroyShip_Audio").transform.GetChild(1);
                Fail_Sound[0].gameObject.GetComponent<AudioSource>().PlayOneShot(Fail_Sound[0].gameObject.GetComponent<AudioSource>().clip);
                Fail_Sound[1] = GameObject.Find("Player").transform.GetChild(3);
                Fail_Sound[1].gameObject.SetActive(true);
                show_Triggers = 17f;
                Audio_Trigger[0] = true;
            }
            else if (random == 1)
            {
                Fail_Sound[0] = GameObject.Find("DestroyShip_Audio").transform.GetChild(2);
                Fail_Sound[0].gameObject.GetComponent<AudioSource>().PlayOneShot(Fail_Sound[0].gameObject.GetComponent<AudioSource>().clip);
                Audio_Trigger[1] = true;
            }
        }
    }
}

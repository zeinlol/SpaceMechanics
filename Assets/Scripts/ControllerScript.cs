﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    public GameObject buttonsMenu;
    public GameObject buttonsExit;
    public GameObject loading;
    public GameObject Canvas;

    public void ShowExitButtons()
    {
        buttonsMenu.SetActive(false);
        buttonsExit.SetActive(true);
    }

    public void BackInMenu() {
        buttonsMenu.SetActive(true);
        buttonsExit.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    [System.Obsolete]
    public void NewGameLoadScenceMain()
    {
        Canvas.active = false;
        loading.active = true;
        Invoke("LoadMain", 2.0f);

    }

    [System.Obsolete]
    public void LoadMain()
    {
        /*_ = */Application.LoadLevelAsync("Main");
    }
}
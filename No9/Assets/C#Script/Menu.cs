using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [Header("解析度下拉選單")]
    public Dropdown ScreenSizeDropdown;
    public void NextScene()
    {
        Application.LoadLevel("No9");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Update()
    {
        switch (ScreenSizeDropdown.value)
        {
            case 0:
                Screen.SetResolution(1920, 1080, false);
                break;
            case 1:
                Screen.SetResolution(1280, 720, false);
                break;
            case 2:
                Screen.SetResolution(800, 480, false);
                break;
        }
        
    }
}

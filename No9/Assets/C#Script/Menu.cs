using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void NextScene()
    {
        Application.LoadLevel("No9");
    }

    public void Quit()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    void Update()
    {
        Invoke("anykeydown", 5f);
    }
    private void anykeydown()
    {
        if (Input.anyKeyDown)
        {
            Application.LoadLevel("Menu");
        }
    }
}

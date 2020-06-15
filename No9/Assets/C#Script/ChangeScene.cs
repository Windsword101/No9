using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public string toScene;
    private string prevScene = "prevScene";

    private void Start()
    {
        PlayerPrefs.SetString(prevScene, Application.loadedLevelName);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Z))
        {
            Application.LoadLevel(toScene);
        }
    }
}

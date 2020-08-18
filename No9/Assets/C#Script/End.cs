using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class End : MonoBehaviour
{
    private Player player;
    
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        player.HP = 99f;
        Invoke("changescene", 15f);
    }
    private void changescene()
    {
        Application.LoadLevel("Menu");

    }
}

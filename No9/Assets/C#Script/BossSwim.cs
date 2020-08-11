using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BossSwim : MonoBehaviour
{
    public static bool swim = false;
    private GameObject swimblock;
    private void Awake()
    {
        swimblock = GameObject.Find("禁止下水");
    }

    // Update is called once per frame
    void Update()
    {
        if (swim == true)
        {
           Destroy(gameObject);
            Destroy(swimblock);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BossSwim : MonoBehaviour
{
    public static bool swim = false;
    public static bool swimhint = false;
    // Update is called once per frame
    void Update()
    {
        if (swim == true)
        {
           Destroy(gameObject);
        }
    }
}

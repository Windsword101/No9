using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossJump : MonoBehaviour
{
    public static bool doublejump = false;
    
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (doublejump == true)
        {
            Destroy(gameObject);
        }
        
        
    }
}

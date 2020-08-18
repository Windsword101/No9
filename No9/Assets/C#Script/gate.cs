using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gate : MonoBehaviour
{
    public static bool gatedestroy = false;
    public static bool gatedestroyhint = false;
    public GameObject triggertono9;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gatedestroy == true) triggertono9.GetComponent<Collider2D>().enabled = true;
    }
}

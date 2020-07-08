using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestoryonload : MonoBehaviour
{
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}

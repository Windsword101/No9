using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroytoxic : MonoBehaviour
{
    void Update()
    {
        if (gate.gatedestroy == true) Destroy(gameObject);
    }
}

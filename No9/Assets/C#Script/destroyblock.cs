using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyblock : MonoBehaviour
{
    private void Update()
    {
        if(BossOctopus.octopus == true)
        {
            Destroy(gameObject);
        }
    }
}

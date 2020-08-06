using UnityEngine;

public class BossTeleport : MonoBehaviour
{
    public static bool teleport = false;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (teleport == true)
        {
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class destroymechanism : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(BossTeleport.teleport == true)
        {
            Destroy(gameObject);
        }
    }
}

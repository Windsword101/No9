using Fungus;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private GameObject trigger,trigger1, teleport, player,grass;
    private void Start()
    {
        trigger = GameObject.Find("trigger");
        trigger1 = GameObject.Find("trigger1");
        teleport = GameObject.Find("teleport");
        player = GameObject.Find("Player");
        grass = GameObject.Find("grass");
    }

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"  && Input.GetKeyDown(KeyCode.Z))
        {
            if(gameObject.name == "trigger1") player.transform.position = teleport.transform.position;
            if(gameObject.name == "teleport") player.transform.position = trigger1.transform.position;
            if (gameObject.name == "trigger") player.transform.position = grass.transform.position;
         
        }
       
    }
}

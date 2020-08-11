using Fungus;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private GameObject trigger,trigger1, teleport, player,grass,doublejump;
    private void Start()
    {
        trigger = GameObject.Find("trigger");
        trigger1 = GameObject.Find("trigger1");
        teleport = GameObject.Find("teleport");
        player = GameObject.Find("Player");
        grass = GameObject.Find("grass");
        doublejump = GameObject.Find("DoubleJumpEnable");

        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Teleport"  && Input.GetKeyDown(KeyCode.Z))
        {
            if(collision.gameObject.name == "trigger1") player.transform.position = teleport.transform.position;
            if(collision.gameObject.name == "teleport") player.transform.position = trigger1.transform.position;
            if(collision.gameObject.name == "trigger") player.transform.position = grass.transform.position;
            if (collision.gameObject.name == "DoubleJumpEnable") BossJump.doublejump = true;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehaviour : StateMachineBehaviour
{
    public float height;
    private Rigidbody2D rig;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rig = GameObject.FindGameObjectWithTag("SwordBoss").GetComponent<Rigidbody2D>();
        rig.constraints = RigidbodyConstraints2D.FreezeRotation;
        rig.AddForce(new Vector2(0, height));
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

   
}

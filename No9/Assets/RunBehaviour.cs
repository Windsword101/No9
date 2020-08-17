using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunBehaviour : StateMachineBehaviour
{
    private int ran;
    public float timer;
    public float minTime;
    public float maxTime;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ran = Random.Range(0, 2);
        timer = Random.Range(minTime, maxTime);
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            animator.SetTrigger("Jump");
            
        }

        /*else if (ran == 1 && timer <= 0)
        {
            animator.SetTrigger("Attack");
            
        }*/

        else timer -= Time.deltaTime;

    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}

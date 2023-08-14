using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour : StateMachineBehaviour
{
    [SerializeField]
    private float timeuntilidle;

    [SerializeField]
    private int numberOfAnimations;

    private bool isIdle;
    private float idleTime;
    private int IdleAnimation;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       ResetIdle();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       if(isIdle == false)
       {
           idleTime += Time.deltaTime;
           
           if(idleTime > timeuntilidle && stateInfo.normalizedTime % 1 < 0.02f){
              isIdle = true;
              IdleAnimation = Random.Range(1,numberOfAnimations + 1);
              IdleAnimation = IdleAnimation * 2 -1;

              animator.SetFloat("IdleAnimations", IdleAnimation - 1);
           }
       }
       else if(stateInfo.normalizedTime % 1 > 0.98)
       {
          ResetIdle();
       }
       animator.SetFloat("IdleAnimations", IdleAnimation, 0.2f, Time.deltaTime);
    }

    private void ResetIdle()
    {
        if(isIdle)
        {
            IdleAnimation--;
        }
        isIdle = false;
        idleTime = 0;
    }
}

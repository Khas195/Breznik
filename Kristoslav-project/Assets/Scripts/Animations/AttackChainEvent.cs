using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AttackChainEvent : StateMachineBehaviour
{

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var characterAnimatorCtrl = animator.gameObject.transform.GetComponentInChildren<CharacterAnimatorControl>();
        characterAnimatorCtrl.SetIsAttack(true);
    }
}

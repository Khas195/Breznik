using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLocks : StateMachineBehaviour
{
    [SerializeField]
    bool lockRotation = false;
    [SerializeField]
    bool lockMovement = false;
    [SerializeField]
    bool lockJump = false;
    [SerializeField]
    bool isWeaponTrailOn = false;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var character = animator.GetComponentInChildren<Character>();
        character.SetLockMovement(lockMovement);
        character.SetLockRotation(lockRotation);
        character.SetLockJump(lockJump);
        var swordTrail = animator.GetComponentInChildren<SwordTrailController>();
        if (swordTrail)
        {
            swordTrail.SetSwordTrail(isWeaponTrailOn);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatorControl : MonoBehaviour
{
    /// <summary>
    /// The animator of the character.
    /// </summary>
    [SerializeField]
    Animator animator = null;



    /// <summary>
    /// The rigidbody of the model of the Character.
    /// </summary>
    [SerializeField]
    Rigidbody hostRb = null;
    [SerializeField]
    Character character = null;
    bool isAttacking = false;
    [SerializeField]
    int maxComboCount = 0;
    [SerializeField]
    int comboCount = 0;


    IMovement movement;
    void Start()
    {
        movement = character.GetMovementBehavior();
    }

    // Update is called once per frame
    void Update()
    {
        var moveSpeed = movement.GetMovementData().currentSpeed;
        animator.SetFloat("VelocityY", hostRb.velocity.y);
        animator.SetFloat("MoveSpeed", moveSpeed);

        if (isAttacking)
        {
        }
    }
    public void PlayAttackAnimation()
    {
        animator.SetTrigger("attack");
    }
    public bool IsPlaying(string animationName)
    {
        var stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName(animationName) && stateInfo.normalizedTime < 1.0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void OnAttackAnimBegin()
    {
        isAttacking = true;
        comboCount += 1;
        //SwitchRootMotion(true);
    }
    public void OnAttackAnimEnd()
    {
        if (comboCount >= maxComboCount || animator.GetBool("attack") == false)
        {
            var stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            isAttacking = false;
            comboCount = 0;
            animator.ResetTrigger("attack");
            //SwitchRootMotion(false);
        }
    }

    private void SwitchRootMotion(bool active)
    {
        animator.applyRootMotion = active;
        animator.updateMode = active ? AnimatorUpdateMode.AnimatePhysics : AnimatorUpdateMode.Normal;
    }

    public bool IsInAttackingAnimation()
    {
        return isAttacking;
    }
}
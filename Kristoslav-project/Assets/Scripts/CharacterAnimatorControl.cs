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
    Animator animator;



    /// <summary>
    /// The rigidbody of the model of the Character.
    /// </summary>
    [SerializeField]
    Rigidbody hostRb;
    [SerializeField]
    Character character;
    bool isAttacking = false;
    [SerializeField]
    int maxComboCount;
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
        var moveSpeed = hostRb.velocity.magnitude;
        moveSpeed = Mathf.Round(moveSpeed);
        if (moveSpeed > 0) {
            if (movement.HadMoveCommand() == false) {
                moveSpeed = 0;
            }
        } 
        animator.SetFloat("VelocityY", hostRb.velocity.y);

        animator.SetFloat("MoveSpeed", moveSpeed);

        animator.SetInteger("ComboCount", comboCount);
    }
    public void PlayAttackAnimation()
    {
        animator.SetTrigger("attack");
    }

    private AnimationClip GetCurrentAnimationClip()
    {
        return animator.GetCurrentAnimatorClipInfo(0)[0].clip;
    }
    public bool IsPlaying(string animationName)
    {
        if (GetCurrentAnimationClip().name == animationName)
        {
            return true;
        }
        return false;
    }
    public void OnAttackAnimBegin()
    {
        isAttacking = true;
        comboCount += 1;
    }
    public void OnAttackAnimEnd()
    {
        isAttacking = false;
        if (comboCount >= maxComboCount)
        {
            comboCount = 0;
            animator.ResetTrigger("attack");
        }
        if (animator.GetBool("attack") == false)
        {
            comboCount = 0;
        }
    }
    public bool IsInAttackingAnimation()
    {
        return isAttacking;
    }
}
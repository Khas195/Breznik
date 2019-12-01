using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

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
    [SerializeField]
    int numOfAttackMoves = 1;
    [SerializeField]
    int numOfHurtAnimations = 1;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var moveSpeed = character.GetCurrentSpeed();
        animator.SetBool("TouchingGround", character.IsTouchingGround());
        animator.SetFloat("VelocityY", hostRb.velocity.y);
        animator.SetFloat("MoveSpeed", moveSpeed);
    }
    public void PlayAttackAnimation()
    {
        var randomAttack = UnityEngine.Random.Range(0, numOfAttackMoves);
        animator.SetTrigger("attack" + randomAttack);

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
    public void SetIsAttack(bool attack)
    {
        if (attack)
        {
            character.OnAttackStart();
        }
        else
        {
            character.OnAttackDone();
        }
    }
    public bool IsInAttackingAnimation()
    {
        return character.IsAttacking();
    }
    public void TriggerDeadAnimation()
    {
        animator.SetTrigger("Die");
    }
    public void PlayDamagedAnimation()
    {
        var randomHurt = UnityEngine.Random.Range(0, numOfHurtAnimations);
        animator.SetTrigger("hurt" + randomHurt);
    }
}
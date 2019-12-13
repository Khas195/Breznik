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
    Quaternion lastRotation = Quaternion.identity;
    void Start()
    {
        lastRotation = hostRb.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        var moveSpeed = character.GetCurrentSpeed();
        animator.SetValueInAnimator("TouchingGround", character.IsTouchingGround());
        animator.SetValueInAnimator("VelocityY", hostRb.velocity.y);
        animator.SetValueInAnimator("MoveSpeed", moveSpeed);
        var rotateSpeed = hostRb.rotation.y - lastRotation.y;
        animator.SetValueInAnimator("RotationSpeed", Mathf.Abs(rotateSpeed));

    }
    public void Revive()
    {
        animator.SetValueInAnimator("Revive");
    }
    public void PlayAttackAnimation()
    {
        var randomAttack = UnityEngine.Random.Range(0, numOfAttackMoves);
        animator.SetValueInAnimator("attack" + randomAttack);

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

    public void TriggerDeadAnimation()
    {
        animator.SetValueInAnimator("Die");
    }
    public void PlayDamagedAnimation()
    {
        var randomHurt = UnityEngine.Random.Range(0, numOfHurtAnimations);
        animator.SetValueInAnimator("hurt" + randomHurt);
    }
}
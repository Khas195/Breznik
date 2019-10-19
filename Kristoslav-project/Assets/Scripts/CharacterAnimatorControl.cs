﻿using System;
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


    [SerializeField]
    List<AnimationClip> attackingClip;
    // Update is called once per frame
    void Update()
    {
        if (IsAttackingAnimationBeingPlayed() == false)
        {
            character.SetAttackingStatus(false);
        }
        else
        {
            character.SetAttackingStatus(true);
        }
        animator.SetFloat("MoveSpeed", hostRb.velocity.magnitude);
        animator.SetFloat("VelocityY", hostRb.velocity.y);
    }
    private bool IsAttackingAnimationBeingPlayed()
    {
        var currentClip = GetCurrentAnimationClip();
        foreach (var clip in attackingClip)
        {
            if (currentClip == clip)
            {
                return true;
            }
        }
        return false;
    }
    public void PlayAttackAnimation()
    {
        animator.SetTrigger("attack");
    }

    private AnimationClip GetCurrentAnimationClip()
    {
        return animator.GetCurrentAnimatorClipInfo(0)[0].clip;
    }
}
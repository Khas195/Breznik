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
    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("MoveSpeed", hostRb.velocity.magnitude);
        animator.SetFloat("VelocityY", hostRb.velocity.y);
    }
    public void PlayAttackAnimation() {
        animator.SetTrigger("attack");
    }

}

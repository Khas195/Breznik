﻿using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// The Character class handles all the possible behavior that a character can have.
///It's handle the character's behaviors by calling the appropriate behavior.
/// </summary>
public class Character : MonoBehaviour
{
    /// <summary>
    /// The RigidBody of the Character's model. <br/>
    /// Need to be set in Unity Editor.
    /// </summary>
    [SerializeField]
    [BoxGroup("Requirements")]
    protected Rigidbody hostRigidBody;

    /// <summary>
    /// Reference to the movement behavior of the character.<br/>
    /// If the character does not have a movement behavior, he/she will not be able to move.
    /// </summary>
    [SerializeField]
    [BoxGroup("Requirements")]
    protected IMovement movementBehavior;

    /// <summary>
    /// The player character's stats
    /// </summary>
    [Space]
    [SerializeField]
    [BoxGroup("Character Stats Holder")]
    protected CharacterData characterData = null;

    [Space]
    /// <summary>
    /// This is event is called when an attack is successfully trigger.
    /// </summary>
    [SerializeField]
    [BoxGroup("Animation Related")]
    protected UnityEvent onCharacterAttack;
    /// <summary>
    /// Reference to the animator control.
    /// </summary>
    [SerializeField]
    [BoxGroup("Animation Related")]
    protected CharacterAnimatorControl animatorControl;

    [Space]
    /// <summary>
    /// An Scriptable Conditions checker that can be created in the Unity Editor.
    /// jumpConditions check whether it is possible to jump.
    /// </summary>
    [SerializeField]
    [BoxGroup("Character conditions check for actions")]
    protected ConditionsChecker jumpConditions;
    /// <summary>
    /// An Scriptable Conditions checker that can be created in the Unity Editor.
    /// moveConditions check whether it is possible to move
    /// </summary>
    [SerializeField]
    [BoxGroup("Character conditions check for actions")]
    protected ConditionsChecker moveConditions;

    /// <summary>
    /// An Scriptable Conditions checker that can be created in the Unity Editor.
    ///  attackConditions check wheter the character can attack.
    /// </summary>
    [SerializeField]
    [BoxGroup("Character conditions check for actions")]
    protected ConditionsChecker attackConditions;

    /// <summary>
    /// An Scriptable Conditions checker that can be created in the Unity Editor.
    /// changeMoveTypeConditions check whether it is possible to change the current move mode. 
    /// </summary>
    [SerializeField]
    [BoxGroup("Character conditions check for actions")]
    protected ConditionsChecker changeMoveTypeConditions;
    public virtual void Awake()
    {
        movementBehavior.SetRigidBody(hostRigidBody);
        movementBehavior.SetMovementData(characterData.movementData);
    }

    /// <summary>
    /// This fucntion ask the moveBehavior of the character to move the character's model.
    /// </summary>
    /// <param name="forward"> fordward is how much the host game object should move forward and backward </param>
    /// <param name="side"> side is how much the host game object should move sideway </param>
    public virtual bool RequestMove(float forward, float side)
    {
        var result = true;
        if (moveConditions.IsSatisfied(this) == false)
        {
            forward = side = 0;
            result = false;
        }
        movementBehavior.MoveRelativeTo(forward, side, hostRigidBody.transform);
        return result;
    }
    /// <summary>
    /// This function invoke an event whenever the character is signal to attack
    /// It returns true if the event is successfully called and vice versa.
    /// </summary>
    /// <returns></returns>
    public virtual bool Attack()
    {
        if (attackConditions.IsSatisfied(this) == false)
        {
            return false;
        }
        onCharacterAttack.Invoke();
        return true;
    }
    /// <summary>
    /// This function ask the moveBehavior of the character to signal the jump function in the next fixed update;.
    /// </summary>
    /// <returns>
    /// True: if successfully called the SignalJump function and vice versa <br />
    /// </returns>
    public virtual bool RequestJump()
    {
        if (jumpConditions.IsSatisfied(this))
        {
            movementBehavior.SignalJump();
            return true;
        }
        return false;
    }
    /// <summary>
    /// This function set the movement Type for the moveBehavior.
    /// </summary>
    /// <param name="moveType"> The movement Type defined in Movement</param>
    /// <returns> 
    /// True: if successfully set the movement mode of the move behavior. <br/>
    /// False: if movementBehavior is null.
    /// </returns>
    public virtual bool RequestMovementType(Movement.MovementType moveType)
    {
        if (changeMoveTypeConditions.IsSatisfied(this))
        {
            movementBehavior.SetMovementMode(moveType);
            return true;
        }
        movementBehavior.SetMovementMode(Movement.MovementType.Walk);
        return false;
    }
    /// <summary>
    /// Get the movement behavior of the character.
    /// </summary>
    /// <returns>The movement behavior of the character. Can be null</returns>
    public IMovement GetMovementBehavior()
    {
        return movementBehavior;
    }

    /// <summary>
    /// Get the character animator control.
    /// </summary>
    /// <returns>The animator control of the character. Can be null</returns>
    public CharacterAnimatorControl GetCharacterAnimator()
    {
        return animatorControl;
    }
    /// <summary>
    /// Get the character stats data of the character.
    /// </summary>
    /// <returns> The character stats of the character. Can be null</returns>
    public virtual CharacterStatsData GetCharacterStats()
    {
        return null;
    }
    /// <summary>
    /// Is called if the character are to be damaged.
    /// </summary>
    /// <param name="damage"> the damage value</param>
    public virtual void BeingDamage(float damage)
    {
        return;
    }
}


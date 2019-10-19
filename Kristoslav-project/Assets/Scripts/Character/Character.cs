using System;
using System.Collections;
using System.Collections.Generic;
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
    Rigidbody hostRigidBody;



    /// <summary>
    /// Reference to the movement behavior of the character.<br/>
    /// If the character does not have a movement behavior, he/she will not be able to move.
    /// </summary>
    [SerializeField]
    IMovement movementBehavior;


    [SerializeField]
    UnityEvent onCharacterAttack;
    [SerializeField]
    bool isAttacking = false;
    void Awake()
    {
        movementBehavior.SetRigidBody(hostRigidBody);
    }

    /// <summary>
    /// This fucntion ask the moveBehavior of the character to move the character's model.
    /// </summary>
    /// <param name="forward"> fordward is how much the host game object should move forward and backward </param>
    /// <param name="side"> side is how much the host game object should move sideway </param>
    /// <returns> 
    /// True: if successfully called the move function. <br/>
    /// False: if moveBehavior is null <br/>
    /// </returns>
    public bool RequestMove(float forward, float side)
    {
        if (movementBehavior == null) return false;
        if (isAttacking == true)
        {
            forward = side = 0;
        }

        movementBehavior.Move(forward, side);
        return true;
    }
    /// <summary>
    /// This function invoke an event whenever the character is signal to attack
    /// It returns true if the event is successfully called and vice versa.
    /// </summary>
    /// <returns></returns>
    public bool Attack()
    {
        Definition.CharacterDebug(this, "try to attack");
        if (movementBehavior.IsTouchingGround() == false)
        {
            Definition.CharacterDebug(this, "attack failed, character is in the air");
            return false;
        }
        isAttacking = true;
        Definition.CharacterDebug(this, "attack triggred successful");
        onCharacterAttack.Invoke();
        return true;
    }
    public void SetAttackingStatus(bool attacking)
    {
        isAttacking = attacking;
    }
    /// <summary>
    /// This function ask the moveBehavior of the character to signal the jump function in the next fixed update;.
    /// </summary>
    /// <returns>
    /// True: if successfully called the SignalJump function. <br />
    /// False: <br/>
    ///   - if the model is not touching the ground
    ///   - If the movementBehaviro is null
    ///   - if there is an attacking animation playing. </returns>
    public bool RequestJump()
    {
        if (movementBehavior == null || !movementBehavior.IsTouchingGround() || isAttacking == true) return false;
        movementBehavior.SignalJump();
        return true;
    }
    /// <summary>
    /// This function set the movement Type for the moveBehavior.
    /// </summary>
    /// <param name="moveType"> The movement Type defined in Movement</param>
    /// <returns> 
    /// True: if successfully set the movement mode of the move behavior. <br/>
    /// False: if movementBehavior is null.
    /// </returns>
    public bool RequestMovementType(Movement.MovementType moveType)
    {
        if (movementBehavior != null)
        {
            movementBehavior.SetMovementMode(moveType);
            return true;
        }
        return false;
    }
    public bool IsAttacking()
    {
        return isAttacking;
    }
}


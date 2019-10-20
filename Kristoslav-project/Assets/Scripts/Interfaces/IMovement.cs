using System;
using UnityEngine;
/**
 * The IMovement interface acts as a generalization of all type of movements in the game.!--
 * It is used by the Player controller to move the target gameobject
 */
public abstract class IMovement : MonoBehaviour {

    /**
     * Different types of movement mode in the game
     */
    public enum MovementType
    {
        Walk, 
        Run 
    }
    [SerializeField]
    /** The container for all movement related data */
    protected MovementData data = null;
    /** The current movement mode */
    protected MovementType moveMode = MovementType.Walk;
    /** All movements actions should be handle in this function*/
    public abstract void Move (float forward, float side);
    /** Signaled that the jump command had been called */
    public abstract void SignalJump();

    public MovementType GetCurrentMoveMode()
    {
        return moveMode;
    }

    /// <summary>
    /// Set the rigid body for the movement behavior.
    /// </summary>
    /// <param name="hostRigidBody"> The rigidbody of the character's model</param>
    public virtual void SetRigidBody(Rigidbody hostRigidBody)
    {
    }

    /** Set the current movement mode */
    public void SetMovementMode(MovementType newMode)
    {
        moveMode = newMode;
    }
    /** 
     * Get the correspondence speed in the data container(MovementData) based on the currnt movement mode
     */
    protected float GetSpeedBasedOnMode()
    {
        float moveSpeed;
        switch (moveMode)
        {
            case MovementType.Run:
                moveSpeed = data.runSpeed ;
                break;
            case MovementType.Walk:
                moveSpeed = data.walkSpeed;
                break;
            default:
                moveSpeed = data.runSpeed;
                break;
        }

        return moveSpeed;
    }
    public virtual bool IsTouchingGround() {
        return true;
    }
    public virtual MovementData GetMovementData() {
        return this.data;
    }
}

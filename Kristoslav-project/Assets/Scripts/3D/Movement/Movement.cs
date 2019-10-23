using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * This class handles all movement related behaviors in 3D
 * The host object (mentioned in blow) is the object which this script will perform its functions on .!--
 * The host object is not necessary be the parent gameobject of the script.!-- 
 */
public class Movement : IMovement
{

    /// <summary>
    /// The Collider of the character's model;
    /// </summary>
    [SerializeField]
    Collider charCollider;
    [SerializeField]
    Collider charAirbornedCollider;
    /**
 * Decide if the host object should move foward accodring the camera's facing direction.!--
 * Instead of move forward according to its own facing direction
 */
    [SerializeField]
    bool rotateTowardMovingDir;
    [SerializeField]
    /**
     * The rotate speed of the host object toward the camera's facing direction.!--
     * Not needed if shouldMoveTowardCameraDirection is false 
     */
    float rotateSpeed;
    /**
     * The list of points which is needed to know whether the host object is airborned or not
     */
    [SerializeField]
    List<Transform> checkGroundsList;


    /// <summary>
    ///  the rigidbody of the character's model.
    /// </summary>
    Rigidbody charRigidbody = null;


    /** cached the forward value in the Move function*/
    int moveForward = 0;
    /** cached the side value in the Move function*/
    int moveSide = 0;
    /** cached the jump signal in the Signal Jump function*/
    bool jumpSignal = false;
    /** Cached transform of the host object */
    Transform targetTransform = null;
    /// <summary>
    /// the distance from the middle of the character's collider's center to ground. 
    /// </summary>
    float distanceToGround;
    void Start()
    {
        Initalize();
    }
    /** 
     * Initalize all the cached variables 
     */
    private void Initalize()
    {
        targetTransform = charRigidbody.transform;
        distanceToGround = charCollider.bounds.extents.y;
    }
    /// <summary>
    /// Set the rigid body of the character's model.
    /// </summary>
    /// <param name="hostRigidBody"> The rigid body of the character's model.</param>
    public override void SetRigidBody(Rigidbody hostRigidBody)
    {
        this.charRigidbody = hostRigidBody;
    }

    /**
     * This function received the player's inputs (forward and side) then saved them to be processed in the next fixed update.
     * If shouldMoveTowardCameraDirection is true then it will rotate the host game object toward the camera's faciing direction first.
     * \param fordward is how much the host game object should move forward and backward
     * \param side is how much the host game object should move sideway
     */
    public override void MoveRelativeTo(float forward, float side, Transform relativeTo)
    {
        if (rotateTowardMovingDir)
        {
            if (forward != 0 || side != 0)
            {
                // Choose whether the forward has a bigger value or the side
                moveForward = (int)(Mathf.Abs(forward) > Mathf.Abs(side) ? forward : side);

                moveForward = Mathf.Abs(moveForward);

                RotateTowardMovingDirection(forward, side, relativeTo);
            }
            else
            {
                moveForward = 0;
                moveSide = 0;
            }
        }
        else
        {
            moveForward = (int)forward;
            moveSide = (int)side;
        }
        Definition.MovementDebug("Movement(forward, side): " + moveForward + ", " + moveSide);
    }

    /**
     * Rotate the host game object toward the forward direction of the movement 
     * \param fordward is how much the host game object should move forward and backward
     * \param side is how much the host game object should move sideway
     */
    private void RotateTowardMovingDirection(float forward, float side, Transform relativeTo)
    {
        var forwardDir = relativeTo.forward * forward;
        var sideDir = relativeTo.right * side;
        var moveDir = forwardDir + sideDir;
        moveDir.y = 0;
        Definition.MovementDebug("Camera Move Direction" + moveDir);
        var newDir = Vector3.RotateTowards(charRigidbody.transform.forward, moveDir, rotateSpeed * Time.deltaTime, 0.0f);
        charRigidbody.rotation = Quaternion.LookRotation(newDir);
    }

    /**
    * This function will signal the target object to jump in the next FixedUpdate.
    * If the character's jump is on cd then nothing will happen.
    */
    public override void SignalJump()
    {
        jumpSignal = true;
    }
    /**
     * This function move the host object according to the forward and side inputs of the player.
     * The movement is performed by manipulating the velocity property of the rigidbody.
     * The speed of the movement is reduced if the host object is airborned.
     * \param speed is the desired movement speed for the host object.
     * \param forward is how much the player need to move forward or backward. 
     * \param side is how much the player need to move sideway.
     */
    void Step(float speed, int forward, int side)
    {
        var forwardDirection = targetTransform.forward * forward;
        var sideDirection = targetTransform.right * side;

        var moveDirection = forwardDirection + sideDirection;
        Definition.MovementDebug("Movement Direction: " + moveDirection);
        var velocity = moveDirection * speed + Vector3.up * charRigidbody.velocity.y;
        charRigidbody.velocity = velocity;

        Definition.MovementDebug("Movement Velocity after each step: " + charRigidbody.velocity);
    }
    private void Update()
    {
        this.data.currentVelocity = charRigidbody.velocity;
        if (charAirbornedCollider) {
            var isAscending = charRigidbody.velocity.y > 0f;
            charCollider.enabled = !isAscending;
            charAirbornedCollider.enabled = isAscending;
        }
    }
    private void FixedUpdate()
    {
        ProcessMovement();
    }

    /**
     * This function process the movement of the host object according to the forward, side and jump inputs
     * The movement speed is also changed if the host object is airborned
     */
    private void ProcessMovement()
    {
        if (jumpSignal)
        {
            Jump();
            jumpSignal = false;
        }
        float moveSpeed = 0;
        moveSpeed = GetSpeedBasedOnMode();
        Step(moveSpeed, moveForward, moveSide);
    }

    /** 
     * Perform the jumping action by adding an impulse force to the host's rigid body according to its up direction.!--
     */
    private void Jump()
    {
        Debug.Log("Character jump with force of " + data.jumpForce);
        charRigidbody.AddForce(Vector3.up * data.jumpForce, ForceMode.Impulse);
    }
    /**
     * Check whether the rigid body of the host object is touching the ground by raycasting from the list of points (checkGroundsList)
     * It is important to know that the desired pivot should be on the bottom of the object.
     */
    public override bool IsTouchingGround()
    {
        foreach (var trans in checkGroundsList)
        {
            if (Physics.Raycast(trans.position, -Vector3.up, distanceToGround + 0.1f))
            {
                return true;
            }
        }
        return false;
    }
    public override bool HadMoveCommand()
    {
        return moveForward != 0 || moveSide != 0;
    }


}

using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
/// <summary>
/// This class handles all movement related behaviors in 3D
/// The host object (mentioned in blow) is the object which this script will perform its functions on .!--
///The host object is    not necessary be the parent gameobject of the script.!-- 
/// </summary>
public class Movement : IMovement
{

    /// <summary>
    /// The Collider of the character's model;
    /// </summary>
    [SerializeField]
    [BoxGroup("Requirements")]
    Collider charCollider = null;

    /// <summary>
    /// The collider this character will use while it is airborned. 
    ///</summary>
    [SerializeField]
    [BoxGroup("Requirements")]
    Collider charAirbornedCollider = null;
    /// <summary>
    /// Decide if the host object should move foward accodring the camera's facing direction.!--
    ///Instead of move forward according to its own facing direction
    /// </summary>
    [SerializeField]
    bool rotateTowardMovingDir = false;
    /// <summary>
    /// The rotate speed of the host object toward the camera's facing direction.!--
    /// Not needed if shouldMoveTowardCameraDirection is false 
    /// </summary>
    [SerializeField]
    [ShowIf("rotateTowardMovingDir")]
    float rotateSpeed = 5f;
    /// <summary>
    ///  The list of points which is needed to know whether the host object is airborned or not
    /// </summary>
    [SerializeField]
    List<Transform> checkGroundsList = new List<Transform>();


    Rigidbody charRigidbody = null;
    float moveForward = 0;
    float moveSide = 0;
    bool jumpSignal = false;
    Transform targetTransform = null;
    float distanceToGround = 0.1f;

    void Start()
    {
        Initalize();
    }
    /// <summary>
    /// Initialize the necessary component for movement to work
    /// </summary>
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

    /// <summary>
    ///  This function received the player's inputs (forward and side) then saved them to be processed in the next fixed update.
    ///If shouldMoveTowardCameraDirection is true then it will rotate the host game object toward the camera's faciing direction first.
    /// </summary>
    /// <param name="forward"> fordward is how much the host game object should move forward and backward</param>
    /// <param name="side"> side is how much the host game object should move sideway</param>
    /// <param name="relativeTo"> If rotate Toward Moving Dirrection is true, use the forward and side of this to rotate the host object toward when moving.</param>
    public override void MoveRelativeTo(float forward, float side, Transform relativeTo)
    {
        if (rotateTowardMovingDir)
        {
            if (forward != 0 || side != 0)
            {
                // Choose whether the forward has a bigger value or the side
                moveForward = (Mathf.Abs(forward) > Mathf.Abs(side) ? forward : side);
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
            moveForward = forward;
            moveSide = side;
        }
    }

    /// <summary>
    ///  Rotate the host game object toward the forward direction of the movement 
    /// </summary>
    /// <param name="forward"> fordward is how much the host game object should move forward and backward</param>
    /// <param name="side"> side is how much the host game object should move sideway</param>
    /// <param name="relativeTo">Rotate the host object toward the host facing direction.</param>
    private void RotateTowardMovingDirection(float forward, float side, Transform relativeTo)
    {
        var forwardDir = relativeTo.forward * forward;
        var sideDir = relativeTo.right * side;
        var moveDir = forwardDir + sideDir;
        moveDir.y = 0;
        var newDir = Vector3.RotateTowards(charRigidbody.transform.forward, moveDir, rotateSpeed * Time.deltaTime, 0.0f);
        charRigidbody.rotation = Quaternion.LookRotation(newDir);
    }

    /// <summary>
    ///  This function will signal the target object to jump in the next FixedUpdate.
    /// If the character's jump is on cd then nothing will happen.
    // </summary>
    public override void SignalJump()
    {
        jumpSignal = true;
    }
    /// <summary>
    ///  This function move the host object according to the forward and side inputs of the player.
    ///  The movement is performed by manipulating the velocity property of the rigidbody.
    ///  The speed of the movement is reduced if the host object is airborned.
    /// </summary>
    /// <param name="speed"> speed is the desired movement speed for the host object.</param>
    /// <param name="forward"> forward is how much the player need to move forward or backward.</param>
    /// <param name="side"> side is how much the player need to move sideway.</param>
    void Step(float speed, float forward, float side)
    {
        var forwardDirection = targetTransform.forward * forward;
        var sideDirection = targetTransform.right * side;

        var moveDirection = forwardDirection + sideDirection;
        var velocity = moveDirection * speed + Vector3.up * charRigidbody.velocity.y;
        charRigidbody.velocity = velocity;
    }
    [SerializeField]
    [ReadOnly]
    float targetSpeed = 0;
    [SerializeField]
    [ReadOnly]
    float currentSpeed = 0;
    [SerializeField]
    float smoothAccel = 0;
    private void Update()
    {
        targetSpeed = (moveForward != 0 | moveSide != 0) ? GetSpeedBasedOnMode() : 0;
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, smoothAccel);

        this.data.currentVelocity = charRigidbody.velocity;
        this.data.currentSpeed = currentSpeed;
        if (charAirbornedCollider)
        {
            var isAscending = charRigidbody.velocity.y > 0f;
            charCollider.enabled = !isAscending;
            charAirbornedCollider.enabled = isAscending;
        }
    }
    private void FixedUpdate()
    {
        ProcessMovement();
    }

    
    /// <summary>
    /// This function process the movement of the host object according to the forward, side and jump inputs
    /// The movement speed is also changed if the host object is airborned
    /// </summary>
    private void ProcessMovement()
    {
        if (jumpSignal)
        {
            Jump();
            jumpSignal = false;
        }
        Step(currentSpeed, moveForward, moveSide);
    }

    /// <summary>
    ///  Perform the jumping action by adding an impulse force to the host's rigid body according to its up direction.!--
    /// </summary>
    private void Jump()
    {
        Debug.Log("Character jump with force of " + data.jumpForce);
        charRigidbody.AddForce(Vector3.up * data.jumpForce, ForceMode.Impulse);
    }
    /// <summary>
    ///  Check whether the rigid body of the host object is touching the ground by raycasting from the list of points (checkGroundsList)
    /// It is important to know that the desired pivot should be on the bottom of the object. 
    /// </summary>
    /// <returns></returns>
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
    /// <summary>
    /// Check if the character received any move command
    /// </summary>
    /// <returns> true or false </returns>
    public override bool HadMoveCommand()
    {
        return moveForward != 0 || moveSide != 0;
    }


}

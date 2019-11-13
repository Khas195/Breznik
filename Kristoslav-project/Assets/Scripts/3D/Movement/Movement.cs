﻿using System;
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
    ///  The list of points which is needed to know whether the host object is airborned or not
    /// </summary>
    [SerializeField]
    List<Transform> checkGroundsList = new List<Transform>();

    [SerializeField]
    [ReadOnly]
    [BoxGroup("Character Speed")]
    float targetSpeed = 0;
    [SerializeField]
    [ReadOnly]
    [BoxGroup("Character Speed")]
    float currentSpeed = 0;
    [SerializeField]
    [BoxGroup("Character Speed")]
    float smoothAccel = 0;


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
    /// </summary>
    /// <param name="forward"> fordward is how much the host game object should move forward and backward</param>
    /// <param name="side"> side is how much the host game object should move sideway</param>
    public override void Move (float forward, float side)
    {
        moveForward = forward;
        moveSide = side;
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
    public override float GetCurrentSpeed(){
        return currentSpeed;
    }
    private void Update()
    {
        targetSpeed = (moveForward != 0 | moveSide != 0) ? GetSpeedBasedOnMode() : 0;
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, smoothAccel);

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

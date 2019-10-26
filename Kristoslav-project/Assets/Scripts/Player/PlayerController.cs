﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
/**
 * This class processes the player's input and tell the character to perform the intended action.
 */
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    /** \brief Reference to the character*/
    Character character = null;
    [SerializeField]
    UnityEvent interact;

    void Update()
    {
        ControlMovement();
    }
    /**
     * All inputs by the player are and should be done in this function .
     * Current Handled Input: . 
     * LeftShift (switching between run and walk mode) .
     * Space (Calls SignalJump function in IMovement) .
     * Recieved Horizontal and vertical then call the Move function in IMovement with those parameters .
     */
    private void ControlMovement()
    {

        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            character.RequestMovementType(IMovement.MovementType.Run);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            character.RequestMovementType(IMovement.MovementType.Walk);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            character.RequestJump();
        }
        if (Input.GetMouseButtonDown(0))
        {
            character.Attack();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            var gameState = GameMaster.GetInstance().GetCurrentGameState();
            if (gameState != null && gameState.GetState() == GameState.States.InGame) {
                interact.Invoke();
            }
        }
        character.RequestMove(vertical, horizontal);

    }
}

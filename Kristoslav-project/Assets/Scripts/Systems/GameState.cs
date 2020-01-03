using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The Game state of the game.
/// </summary>
public class GameState : State
{
    [Serializable]
    public enum States
    {
        Loading,
        MainMenu,
        InGame,
        GamePaused,
        InDiagloues,
        InInventory,
        Cutscene,
        DefaultState
    }
    /// <summary>
    /// The state's type of the current game state.
    /// </summary>
    [SerializeField]
    States state = States.InGame;
    /// <summary>
    /// Get the state type/name of the current game state.
    /// </summary>
    /// <returns>the state type/name</returns>
    public States GetState()
    {
        return state;
    }
}

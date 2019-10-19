using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The Game state of the game.
/// </summary>
public class GameState : State 
{
    public enum States
    {
        Loading,
        MainMenu,
        InGame,
        GamePaused 
    }
    /// <summary>
    /// The state's type of the current game state.
    /// </summary>
    [SerializeField]
    States state;
    /// <summary>
    /// Get the state type/name of the current game state.
    /// </summary>
    /// <returns>the state type/name</returns>
    public States GetState() {
        return state;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The Game state of the game.
/// </summary>
public abstract class GameState : MonoBehaviour
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
    [SerializeField]
    List<States> allowedTransitions = new List<States>();

    public bool Cantransition(States targetState)
    {
        for (int i = 0; i < allowedTransitions.Count; i++)
        {
            if (allowedTransitions[i] == targetState)
            {
                return true;
            }
        }
        return false;
    }
    public abstract void OnStateExit();
    public abstract void OnStateEnter();

    /// <summary>
    /// Get the state type/name of the current game state.
    /// </summary>
    /// <returns>the state type/name</returns>
    public States GetState()
    {
        return state;
    }
}

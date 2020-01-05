using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Control the flow of the game. 
/// </summary>
public class GameMaster : SingletonMonobehavior<GameMaster>
{
    /// <summary>
    /// The State stack that is used to manage the game states.
    /// The top state is always the current state of the game master.
    /// </summary>
    [SerializeField]
    [ReadOnly]
    GameState currentState;

    /// <summary>
    /// The possible game states in a certain scene.
    /// The first possible state will start as the base state.
    /// </summary>
    [Tooltip("Use the first Game State as default state or startup state")]
    [SerializeField]
    List<GameState> possibleGameStates = new List<GameState>();

    [SerializeField]
    GameObject defaultGameState = null;


    [SerializeField]
    UnityEvent OnGameStart = new UnityEvent();

    public GameState GetCurrentGameState()
    {
        return currentState;
    }

    protected override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        FindAllPossibleStates();
    }

    public bool IsInState(GameState.States stateToCheck)
    {
        if (currentState && currentState.GetState() == stateToCheck)
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// Set the time scale of the game.
    /// </summary>
    /// <param name="timeScale">The new Time Scale Of the game.</param>
    public void SetGameTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }
    /// <summary>
    /// Find all the possible game states in the current scene.
    /// A game object holder with a tag "GameStates" with the possible game states as child is needed.
    /// Whether the child object is active or not is irrelevant.
    /// </summary>
    private void FindAllPossibleStates()
    {
        var gameStateHolder = GameObject.FindGameObjectWithTag("GameStates");
        currentState = null;
        if (gameStateHolder != null)
        {
            var possibleStates = gameStateHolder.GetComponentsInChildren<GameState>(includeInactive: true);
            possibleGameStates.AddRange(possibleStates);
            RequestGameState(possibleStates[0].GetState());
        }
        else
        {
            var defaultState = this.defaultGameState.GetComponent<GameState>();
            possibleGameStates.Add(defaultState);
            RequestGameState(defaultState.GetState());
        }
    }
    /// <summary>
    /// Show or hide mouse in the current scene.
    /// </summary>
    /// <param name="isVisible"> Whether the mouse should be visible or not.</param>
    public void SetMouseVisibility(bool isVisible)
    {
        Cursor.visible = isVisible;
        Cursor.lockState = isVisible ? CursorLockMode.None : CursorLockMode.Locked;
    }

    /// <summary>
    /// Request a new game state for the game.
    /// If the requested state is valid then called on Pop on all states in stack.
    /// </summary>
    /// <param name="requestState">The requested state.</param>
    public void RequestGameState(GameState.States requestState)
    {
        var stateToTransit = LookupGameState(requestState);
        if (stateToTransit == null)
        {
            Logger.GameMasterDebug(this, "trying to request a state that does not exist.");
            return;
        }
        if (currentState != null)
        {
            if (currentState.GetState() == requestState)
            {
                Logger.GameMasterDebug(this, "trying to request a state that is already running.");
                return;
            }
            if (currentState.Cantransition(requestState))
            {
                TransitToState(stateToTransit);
            }
            else
            {
                Logger.GameMasterDebug(this, "Transition from " + currentState.GetState() + " to " + requestState + " is not allowed");
            }
        }
        else
        {
            TransitToState(stateToTransit);
        }
    }

    private void TransitToState(GameState enteringState)
    {
        if (currentState != null)
        {
            currentState.OnStateExit();
        }
        enteringState.OnStateEnter();
        currentState = enteringState;

    }


    /// <summary>
    /// Look up the requested state in the list of possible game states.
    /// </summary>
    /// <param name="requestState">The requested state.</param>
    /// <returns>Null if the requested state is invalid and the request state if the  requested state is valid.</returns>
    private GameState LookupGameState(GameState.States requestState)
    {
        var result = possibleGameStates.Find(state => state.GetState() == requestState);
        return result;
    }
    /// <summary>
    /// Exit the game.
    /// </summary>
    public void ExitGame()
    {
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;

#else
        Application.Quit();
#endif
    }
    public void StartGame()
    {
        Debug.Log("Start Game");
        OnGameStart.Invoke();
    }
    public void GoToInGame()
    {
        RequestGameState(GameState.States.InGame);
    }
    public void PausedGame()
    {
        RequestGameState(GameState.States.GamePaused);
    }


    public bool IsGamePaused()
    {
        if (Time.timeScale <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    StateStack<GameState> gameStateStack = new StateStack<GameState>();





    /// <summary>
    /// The possible game states in a certain scene.
    /// The first possible state will start as the base state.
    /// </summary>
    [Tooltip("Use the first Game State as default state or startup state")]
    [SerializeField]
    List<GameState> possibleGameStates = new List<GameState>();



    [SerializeField]
    Text canInteractText;

    /// <summary>
    /// The name of the scene that is going to be loaded when moving into the LoadingScene.
    /// </summary>
    string sceneToLoad;

    public GameState GetCurrentGameState()
    {
        return gameStateStack.GetPeek();
    }

    protected override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        Init();
    }
    private void Init()
    {
        FindAllPossibleStates();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    /// <summary>
    /// Called whenever a scene is loaded.
    /// Clear all possibleGameStates from previous scene and then find the new possible states in the loaded scene.
    /// </summary>
    /// <param name="scene"> The loaded scene.</param>
    /// <param name="mode"> The mode of which the scene is loaded</param>
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        possibleGameStates.Clear();
        FindAllPossibleStates();
    }
    public bool IsInState(GameState.States stateToCheck)
    {
        var currentState = this.gameStateStack.GetPeek();
        if (currentState && currentState.GetState() == stateToCheck ){
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
        var possibleStates = gameStateHolder.GetComponentsInChildren<GameState>(includeInactive: true);
        possibleGameStates.AddRange(possibleStates);
        gameStateStack.EmptyStack();
        RequestGameState(possibleStates[0].GetState());
    }
    /// <summary>
    /// Can only be called by the Loading State.
    /// Used for loading operation in the loading Scene.
    /// </summary>
    /// <param name="slider"> The slider to show the progress.</param>
    /// <param name="loadingText">The text to show the progress.</param>
    public void LoadScene(Slider slider, Text loadingText)
    {
        var currentState = gameStateStack.GetPeek();
        if (currentState == null || currentState.GetState() != GameState.States.Loading)
        {
            Logger.GameMasterDebug(this, " tried to load a scene while game master is not in loading state");
            return;
        }
        StartCoroutine(LoadAsyn(slider, loadingText));
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
    /// Load the sceneToLoad in the background.
    /// After which ask the user to press space bar to load the scene.
    /// </summary>
    /// <param name="slider"> The slider to show the progress.</param>
    /// <param name="loadingText">The text to show the progress.</param>
    /// <returns></returns>
    IEnumerator LoadAsyn(Slider slider, Text loadingText)
    {
        yield return null;
        AsyncOperation asynOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        asynOperation.allowSceneActivation = false;
        while (!asynOperation.isDone)
        {
            slider.value = asynOperation.progress;
            loadingText.text = "Loadding.... " + slider.value * 100 + " %";
            if (asynOperation.progress >= 0.9f)
            {
                slider.gameObject.SetActive(false);
                loadingText.text = "Press space bar to continue";
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    gameStateStack.EmptyStack();
                    asynOperation.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }
    /// <summary>
    /// Request a new game state for the game.
    /// If the requested state is valid then called on Pop on all states in stack.
    /// </summary>
    /// <param name="requestState">The requested state.</param>
    public bool RequestGameState(GameState.States requestState)
    {
        var result = LookupGameState(requestState);
        if (result == null)
        {
            Logger.GameMasterDebug(this, "trying to request a state that does not exist.");
            return false;
        }
        var currentState = (GameState)gameStateStack.GetPeek();
        if (currentState == null)
        {
            gameStateStack.EmptyStack();
            gameStateStack.Push(result);
            return true;
        }
        else if (currentState.GetState() == requestState)
        {
            return false;
        }
        else
        {
            return TryToTransitToState(requestState, result, currentState);
        }
    }

    // TODO: do something about this function plz.
    private bool TryToTransitToState(GameState.States requestState, GameState result, GameState currentState)
    {
        var currentStateType = currentState.GetState();
        switch (requestState)
        {
            case GameState.States.InDiagloues:
                if (currentStateType == GameState.States.InGame)
                {
                    gameStateStack.Push(result);
                    return true;
                }
                break;
            case GameState.States.InGame:
                if (currentStateType == GameState.States.InDiagloues)
                {
                    gameStateStack.Pop();
                    return true;
                }
                else if (currentStateType == GameState.States.InInventory)
                {
                    gameStateStack.Pop();
                    return true;
                }
                else
                {
                    gameStateStack.EmptyStack();
                    gameStateStack.Push(result);
                    return true;
                }
            case GameState.States.InInventory:
                if (currentStateType == GameState.States.InGame)
                {
                    gameStateStack.Push(result);
                    return true;
                }
                break;
            default:
                gameStateStack.EmptyStack();
                gameStateStack.Push(result);
                return true;
        }
        return false;
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
    /// Request load a new scene.
    /// Call OnPop on all current states in the game state stack.
    /// </summary>
    /// <param name="sceneName"></param>
    public void RequestLoadScene(string sceneName)
    {
        gameStateStack.EmptyStack();
        SceneManager.LoadScene("LoadingScene");
        sceneToLoad = sceneName;
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
    /// <summary>
    ///  Go to the arena scene.
    /// </summary>
    public void GoToArena()
    {
        RequestLoadScene("ArenaScene");
    }
}


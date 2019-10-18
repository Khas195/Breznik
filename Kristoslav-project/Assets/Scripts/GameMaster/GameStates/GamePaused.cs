using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Paused State of the Game.
/// </summary>
public class GamePaused : GameState
{
    /// <summary>
    /// The InGame menu holder.
    /// </summary>
    [SerializeField]
    GameObject inGameMenuHolder;
    /// <summary>
    /// Called when game paused state is poped out of the stack.
    /// Hide in game menu and unpaused the game.
    /// </summary>
    public override void OnPopped()
    {
        base.OnPopped();
        this.gameObject.SetActive(false);
        inGameMenuHolder.SetActive(false);
        GameMaster.GetInstance().SetGameTimeScale(1f);
    }

    /// <summary>
    /// Called when game paused state is pushed onto the stack.
    /// Show the in game menu and paused the game.
    /// </summary>
    public override void OnPushed()
    {
        base.OnPushed();
        this.gameObject.SetActive(true);
        inGameMenuHolder.SetActive(true);
        GameMaster.GetInstance().SetGameTimeScale(0f);
    }
    /// <summary>
    /// Tell the game master to go to the In Game State.
    /// </summary>
    public void ResumeGame()
    {
        GameMaster.GetInstance().RequestGameState(GameState.States.InGame);
    }
    /// <summary>
    /// Tell the game master to Exit the game.
    /// </summary>
    public void ExitGame()
    {
        GameMaster.GetInstance().ExitGame();
    }
    /// <summary>
    /// Tell the game master to go to the MainMenu.
    /// </summary>
    public void BackToMenu()
    {
        GameMaster.GetInstance().RequestLoadScene("MainMenuScene");
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Paused State of the Game.
/// </summary>
public class GamePaused : GameState
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameMaster.GetInstance().RequestGameState(States.InGame);
        }
    }

    public override void OnStateExit()
    {
        GameMaster.GetInstance().SetGameTimeScale(1.0f);
        GameMaster.GetInstance().SetMouseVisibility(false);
        InGameUIManager.GetInstance().TurnOffPausedMenu();
        InGameUIManager.GetInstance().TurnOnOverlay();
        this.gameObject.SetActive(false);
    }

    public override void OnStateEnter()
    {
        this.gameObject.SetActive(true);
        GameMaster.GetInstance().SetMouseVisibility(true);
        GameMaster.GetInstance().SetGameTimeScale(0.0f);
        InGameUIManager.GetInstance().TurnOnPausedMenu();
        InGameUIManager.GetInstance().TurnOffOverlay();
    }
}

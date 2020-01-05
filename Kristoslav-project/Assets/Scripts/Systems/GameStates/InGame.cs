using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// The In game state of the game.
/// </summary>
public class InGame : GameState
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameMaster.GetInstance().RequestGameState(GameState.States.GamePaused);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameMaster.GetInstance().RequestGameState(GameState.States.InInventory);
        }
    }

    public override void OnStateExit()
    {
        GameMaster.GetInstance().SetGameTimeScale(0.0f);
        this.gameObject.SetActive(false);
        GameMaster.GetInstance().SetMouseVisibility(true);
        InGameUIManager.GetInstance().TurnOffOverlay();
    }

    public override void OnStateEnter()
    {
        GameMaster.GetInstance().SetGameTimeScale(1.0f);
        this.gameObject.SetActive(true);
        GameMaster.GetInstance().SetMouseVisibility(false);
        InGameUIManager.GetInstance().TurnOnOverlay();
    }
}

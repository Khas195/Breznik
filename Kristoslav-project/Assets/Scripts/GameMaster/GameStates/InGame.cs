using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The In game state of the game.
/// </summary>
public class InGame : GameState
{
    [SerializeField]
    GameObject inGameUIs = null;
    [SerializeField]
    Text interactCue = null;
    /// <summary>
    /// Called when the in game state is poped out of the stack.
    /// Show the mouse.
    /// </summary>
    public override void OnPopped()
    {
        base.OnPopped();
        this.gameObject.SetActive(false);
        inGameUIs.SetActive(false);
        GameMaster.GetInstance().SetMouseVisibility(true);
    }

    /// <summary>
    /// Called when the in game state is poped out of the stack.
    /// hide the mouse.
    /// </summary>
    public override void OnPushed()
    {
        base.OnPushed();
        this.gameObject.SetActive(true);
        inGameUIs.SetActive(true);
        GameMaster.GetInstance().SetMouseVisibility(false);
    }
    public void OnInteractableFocusChange(IInteractable interact)
    {
        if (interact.IsFocus())
        {
            interactCue.gameObject.SetActive(true);
            interactCue.text = "E - " + interact.GetKindOfInteraction() + " " + interact.GetName();
        }
        else
        {
            interactCue.gameObject.SetActive(false);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            GameMaster.GetInstance().RequestGameState(GameState.States.GamePaused);
        } 
        if (Input.GetKeyDown(KeyCode.I)){
            GameMaster.GetInstance().RequestGameState(GameState.States.InInventory);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The In game state of the game.
/// </summary>
public class InGame : GameState
{
    /// <summary>
    /// Called when the in game state is poped out of the stack.
    /// Show the mouse.
    /// </summary>
    public override void OnPopped()
    {
        base.OnPopped();
        this.gameObject.SetActive(false);
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
        GameMaster.GetInstance().SetMouseVisibility(false);
    }
}

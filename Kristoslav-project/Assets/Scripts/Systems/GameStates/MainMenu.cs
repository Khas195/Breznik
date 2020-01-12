using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The main menu state of the game.
/// </summary>
public class MainMenu : GameState
{
    public override void OnStateEnter()
    {
        GameMaster.GetInstance().SetGameTimeScale(0.0f);
        this.gameObject.SetActive(true);
        MainMenuUIManager.GetInstance().Show();
    }

    public override void OnStateExit()
    {
        GameMaster.GetInstance().SetGameTimeScale(1.0f);
        this.gameObject.SetActive(false);
        MainMenuUIManager.GetInstance().Hide();
    }
}

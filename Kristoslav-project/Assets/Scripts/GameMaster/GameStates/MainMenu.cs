using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The main menu state of the game.
/// </summary>
public class MainMenu : GameState
{
    /// <summary>
    /// The start button to go to the main game scene.
    /// </summary>
    [SerializeField]
    Button startButton = null;


    /// <summary>
    /// Called then Main Menu is poped out of the stack.
    /// </summary>
    public override void OnPopped()
    {
        base.OnPopped();
        this.gameObject.SetActive(false);
    }
    /// <summary>
    /// Called then Main Menu is pushed intpo the stack.
    /// Make the start button uninteractable.
    /// </summary>
    public override void OnPushed()
    {
        base.OnPushed();
        this.gameObject.SetActive(true);
        startButton.interactable = false;
    }
    public void StartGame()
    {

    }
    /// <summary>
    /// Tell the game master to go to the Arena scene.
    /// </summary>
    public void GoToArena()
    {
        GameMaster.GetInstance().GoToArena();
    }
    /// <summary>
    /// Tell the game master to exit the game.
    /// </summary>
    public void ExitGame()
    {
        GameMaster.GetInstance().ExitGame();
    }
}

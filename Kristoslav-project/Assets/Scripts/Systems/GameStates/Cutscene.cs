
using UnityEngine;

public class Cutscene : GameState
{
    public override void OnStateEnter()
    {
        GameMaster.GetInstance().SetGameTimeScale(0.0f);
        GameMaster.GetInstance().SetMouseVisibility(false);
        InGameUIManager.GetInstance().TurnOffOverlay();
        this.gameObject.SetActive(true);
    }

    public override void OnStateExit()
    {
        this.gameObject.SetActive(false);
        GameMaster.GetInstance().SetMouseVisibility(true);
        GameMaster.GetInstance().SetGameTimeScale(1.0f);
        InGameUIManager.GetInstance().TurnOnOverlay();
    }
}

using UnityEngine;

public class InInventory : GameState
{
    public override void OnPopped()
    {
        base.OnPopped();
        InventorySystem.GetInstance().HideUI();
        GameMaster.GetInstance().SetMouseVisibility(false);
        this.gameObject.SetActive(false);
    }

    public override void OnPressed()
    {
        base.OnPressed();
    }

    public override void OnPushed()
    {
        base.OnPushed();
        InventorySystem.GetInstance().ShowUI();
        GameMaster.GetInstance().SetMouseVisibility(true);
        this.gameObject.SetActive(true);
    }

    public override void OnReturnPeek()
    {
        base.OnReturnPeek();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Escape))
        {
            GameMaster.GetInstance().RequestGameState(GameState.States.InGame);
        }
    }
}

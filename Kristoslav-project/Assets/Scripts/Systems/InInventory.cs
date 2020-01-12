using UnityEngine;

public class InInventory : GameState
{
    public override void OnStateEnter()
    {
        InventorySystem.GetInstance().ShowUI();
        GameMaster.GetInstance().SetMouseVisibility(true);
        this.gameObject.SetActive(true);
    }

    public override void OnStateExit()
    {
        InventorySystem.GetInstance().HideUI();
        GameMaster.GetInstance().SetMouseVisibility(false);
        this.gameObject.SetActive(false);
    }

    public override string ToString()
    {
        return base.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Escape))
        {
            GameMaster.GetInstance().RequestGameState(GameState.States.InGame);
        }
    }
}

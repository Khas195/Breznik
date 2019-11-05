
using UnityEngine;

[CreateAssetMenu(fileName = "Objective", menuName = "Quest/Objective/Collect", order = 0)]
public class CollectObjective : Objective
{
    public ItemObject toCollect;

    public override void Activate()
    {
        InventorySystem.GetInstance().onItemCollected.AddListener(OnItemCollected);
    }

    public override bool IsCompleted()
    {
        return base.IsCompleted();
    }
    public void OnItemCollected ( ItemObject itemAdded) {
        if (itemAdded == toCollect) {
            this.IncreaseAchieved();
        }
    }

    public override void Deactivate()
    {
        InventorySystem.GetInstance().onItemCollected.RemoveListener(OnItemCollected);
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "IsInInventory", menuName = "BehaviorCondition/IsInInventory")]
public class IsInInventory : CharacterBehaviorCondition
{
    [SerializeField]
    bool reverse = false;
    public override bool IsSatisfied(Character character)
    {
        return reverse ? !InventorySystem.GetInstance().IsOpen() : InventorySystem.GetInstance().IsOpen() ;
    }
}
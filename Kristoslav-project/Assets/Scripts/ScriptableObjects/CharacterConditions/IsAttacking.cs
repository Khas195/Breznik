using UnityEngine;

[CreateAssetMenu(fileName = "IsAttacking", menuName = "BehaviorCondition/IsAttacking")]
public class IsAttacking : CharacterBehaviorCondition
{
    [SerializeField]
    bool reverse = false;
    public override bool IsSatisfied(Character character)
    {
        return reverse ? !character.IsAttacking() : character.IsAttacking();
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "IsNotInAttackingAnimation", menuName = "BehaviorCondition/IsNotInAttackingAnimation")]
public class IsNotAttacking : CharacterBehaviorCondition
{
    public override bool IsSatisfied(Character character)
    {
        return character.GetCharacterAnimator().IsInAttackingAnimation() == false;
    }
}

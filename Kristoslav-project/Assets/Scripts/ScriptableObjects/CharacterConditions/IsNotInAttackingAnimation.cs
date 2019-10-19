using UnityEngine;

[CreateAssetMenu(fileName = "IsNotInAttackingAnimation", menuName = "BehaviorCondition/IsNotAttacking")]
/// <summary>
/// Check if the any attack animation is being play.
/// Required the character to have an CharacterAnimatorController
/// </summary>
public class IsNotInAttackingAnimation : CharacterBehaviorCondition
{
    public override bool IsSatisfied(Character character)
    {
        var animator = character.GetCharacterAnimator();
        return animator.IsAttackingAnimationBeingPlayed() == false;
    }
}

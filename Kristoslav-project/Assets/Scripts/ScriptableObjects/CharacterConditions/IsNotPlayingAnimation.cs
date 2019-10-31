using UnityEngine;

[CreateAssetMenu(fileName = "IsNotPlayingAnimation", menuName = "BehaviorCondition/IsNotPlayingAnimation")]
public class IsNotPlayingAnimation : CharacterBehaviorCondition
{
    [SerializeField]

    string animationName = "Empty";
    public override bool IsSatisfied(Character character)
    {
        var charAnimControl = character.GetCharacterAnimator();
        if ( charAnimControl.IsPlaying(animationName)) {
            return false;
        }
        return true;
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "InNotPlayingFallingAnimation", menuName = "BehaviorCondition/IsNotPlayingFallingAnimation")]
public class IsNotPlayingFallingAnimation : CharacterBehaviorCondition
{
    [SerializeField]
    string fallingAnimationName;
    public override bool IsSatisfied(Character character)
    {
        var charAnimControl = character.GetCharacterAnimator();
        if ( charAnimControl.IsPlaying(fallingAnimationName)) {
            return false;
        }
        return true;
    }
}

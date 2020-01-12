using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Rotate")]
public class RotateAction : Action
{
    public override void Act(NPCController controller)
    {
        controller.RotateToward(controller.GetChaseTarget());
    }
}

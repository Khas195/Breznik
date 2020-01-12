using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/IsInChaseRange")]
public class IsInChaseRange : Decision
{
    public override bool Decide(NPCController controller)
    {
        var chaseTarget = controller.GetChaseTarget();

        return controller.IsOutOfRange(chaseTarget.position) == false;
    }
}


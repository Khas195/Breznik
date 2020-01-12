using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/IsInAttackRange")]
public class IsInAttackRange : Decision
{
    public override bool Decide(NPCController controller)
    {
        return controller.IsInAttackRange(controller.GetChaseTarget().position);
    }
}


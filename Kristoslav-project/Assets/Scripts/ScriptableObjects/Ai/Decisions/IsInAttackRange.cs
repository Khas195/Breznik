using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/IsInAttackRange")]
public class IsInAttackRange : Decision
{
    public override bool Decide(NPCController controller)
    {
        if (controller.IsInAttackRange(controller.GetChaseTarget().position))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/InlineOfAttack")]
public class InLineOfAttackDecision : Decision
{
    public override bool Decide(NPCController controller)
    {
        return controller.IsInAttackLine(controller.GetChaseTarget());
    }
}

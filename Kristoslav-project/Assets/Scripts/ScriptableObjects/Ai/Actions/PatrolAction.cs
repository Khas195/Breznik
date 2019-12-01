using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PluggableAI/Actions/Patrol")]
public class PatrolAction : Action
{
    public override void Act(NPCController controller)
    {
        Patrol(controller);
    }

    void Patrol(NPCController controller)
    {
        if (controller.HasReachedCurrentDestination())
        {
            controller.SetMovement(IMovement.MovementType.Walk);
            var nextDestination = controller.GetRandomPointInArea();
            controller.SetDestination(nextDestination);
        }
    }
}

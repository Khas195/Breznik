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
            Vector3 nextDestination = Vector3.zero;
            do
            {
                nextDestination = controller.GetRandomPointInArea();
            }
            while (controller.SetDestination(nextDestination) == false);
        }
    }
}

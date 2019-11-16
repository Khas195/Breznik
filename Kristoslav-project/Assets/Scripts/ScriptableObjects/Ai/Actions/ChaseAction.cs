using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PluggableAI/Actions/Chase")]
public class ChaseAction : Action
{
    public override void Act(NPCController controller)
    {
        Chase(controller);
    }

    private void Chase(NPCController controller)
    {
        Transform currentTarget = controller.GetChaseTarget();
        controller.SetDestination(currentTarget.position);
    }
}

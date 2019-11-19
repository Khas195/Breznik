using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/SpotPlayer")]
public class SpotPlayer : Decision
{
    public override bool Decide(NPCController controller)
    {
        bool playerVisible = controller.LookForHostile();
        return playerVisible;
    }

}

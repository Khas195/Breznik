using System;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : SingletonMonobehavior<MonsterManager>
{
    [SerializeField]
    List<NPCController> activeMonsters = new List<NPCController>();
    [SerializeField]
    List<NPCController> inactiveMonsters = new List<NPCController>();

    public void OnAiActivated(NPCController activatedMonster)
    {
        if (activeMonsters.Contains(activatedMonster))
        {
            Debug.LogWarning("Trying to activate a monster while it is active " + activatedMonster);
        }
        else
        {
            if (inactiveMonsters.Contains(activatedMonster))
            {
                inactiveMonsters.Remove(activatedMonster);
            }
            activeMonsters.Add(activatedMonster);
        }
    }
    public void OnAiDeactivated(NPCController deactivatedMonster)
    {

        if (inactiveMonsters.Contains(deactivatedMonster))
        {
            Debug.LogWarning("Trying to deactivate a monster while it is inactive " + deactivatedMonster);
        }
        else
        {
            if (activeMonsters.Contains(deactivatedMonster))
            {
                activeMonsters.Remove(deactivatedMonster);
            }
            inactiveMonsters.Add(deactivatedMonster);
        }
    }
    public void ReviveAll()
    {
        for (int i = 0; i < inactiveMonsters.Count; i++)
        {
            inactiveMonsters[i].Revive();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quest/Quest", order = 0)]
public class Quest : ScriptableObject
{
    [TextArea(15, 20)]
    public string description = "";
    public List<Objective> objectives = new List<Objective>();
    public void Activate()
    {
        for (int i = 0; i < objectives.Count; i++)
        {
            objectives[i].Activate();
        }
    }
    public virtual bool IsCompleted()
    {
        for (int i = 0; i < objectives.Count; i++)
        {
            if (objectives[i].IsCompleted() == false)
            {
                return false;
            }
        }
        return true;
    }
    public void Deactivate()
    {
        for (int i = 0; i < objectives.Count; i++)
        {
            objectives[i].Deactivate();
        }
    }

    public void Reset()
    {
        for (int i = 0; i < objectives.Count; i++)
        {
            objectives[i].Reset();
        }
    }
}

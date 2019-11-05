using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Objective : ScriptableObject
{
    [TextArea(15, 20)]
    public string description = "";
    public int amount = 1;
    public int achieved = 0;
    public virtual void Activate() {
    }
    public virtual bool IsCompleted()
    {
        return achieved >= amount;
    }
    public void IncreaseAchieved()
    {
        achieved++;
    }
    public virtual void Deactivate() {
    }
}

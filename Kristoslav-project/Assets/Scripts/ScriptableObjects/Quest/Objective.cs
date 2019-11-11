using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Objective : ScriptableObject
{
    [TextArea(15, 20)]
    public string description = "";
    public int targetAmount = 1;
    public int achieved = 0;
    public virtual void Activate() {
    }
    public virtual bool IsCompleted()
    {
        return achieved >= targetAmount;
    }
    
    public virtual void Deactivate() {
    }
    public virtual void Reset(){
        achieved = 0;
    }
}

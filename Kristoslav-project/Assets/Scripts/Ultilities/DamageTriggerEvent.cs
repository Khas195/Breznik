using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class ComboDamageTrigger : UnityEvent<int> { }
public class DamageTriggerEvent : MonoBehaviour
{
    [SerializeField]
    UnityEvent OnDeathAnimationDone = new UnityEvent();
    public ComboDamageTrigger OnDamageTrigger = new ComboDamageTrigger();
    public void DealsDamage(int comboCount)
    {
        Debug.Log("Deals attack called - " + comboCount);
        OnDamageTrigger.Invoke(comboCount);
    }
    public void DeathAnimationDone()
    {
        OnDeathAnimationDone.Invoke();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class ComboDamageTrigger : UnityEvent<int> { }
/*
This script's name should be changed cause it is handling all Aniamtion events not just Damage Trigger Event.
*/
public class DamageTriggerEvent : MonoBehaviour
{
    [SerializeField]
    bool playSounds = false;
    [SerializeField]
    [ShowIf("playSounds")]
    AudioSource swordSwingSource = null;

    [SerializeField]
    UnityEvent OnDeathAnimationDone = new UnityEvent();
    public ComboDamageTrigger OnDamageTrigger = new ComboDamageTrigger();
    public void DealsDamage(int comboCount)
    {
        Debug.Log("Deals attack called - " + comboCount);
        OnDamageTrigger.Invoke(comboCount);
        if (playSounds)
        {
            var soundsSys = SoundSystem.GetInstance();
            if (soundsSys)
            {
                var clipToPlay = soundsSys.GetClip(SoundDictionary.SoundList.SwordSwing);
                swordSwingSource.clip = clipToPlay;
                swordSwingSource.Play();
            }
        }

    }
    public void DeathAnimationDone()
    {
        OnDeathAnimationDone.Invoke();
    }
}


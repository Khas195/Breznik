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
    bool playFootEffects = false;
    [SerializeField]
    [ShowIf("playFootEffects")]
    Transform leftFootLocation = null;
    [SerializeField]
    [ShowIf("playFootEffects")]
    Transform rightFootLocation = null;
    [SerializeField]
    bool playFootSounds = false;
    [SerializeField]
    [ShowIf("playFootSounds")]
    AudioSource footSource = null;

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
    public void FootFall(int side)
    {
        if (playFootEffects == false) return;

        var vfx = VFXSystem.GetInstance();
        if (vfx)
        {
            if (side == 0)
            {
                vfx.PlayEffect(VFXResources.VFXList.FootFall, leftFootLocation.position, Quaternion.identity);
            }
            else if (side == 1)
            {
                vfx.PlayEffect(VFXResources.VFXList.FootFall, rightFootLocation.position, Quaternion.identity);
            }
        }
        var soundsSys = SoundSystem.GetInstance();
        if (soundsSys)
        {
            var clipToPlay = soundsSys.GetClip(SoundDictionary.SoundList.FootFall);
            footSource.clip = clipToPlay;
            footSource.Play();
        }
    }
}


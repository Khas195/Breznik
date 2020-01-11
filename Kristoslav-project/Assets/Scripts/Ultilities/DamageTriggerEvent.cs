using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class ComboDamageTrigger : UnityEvent<int> { }
public class DamageTriggerEvent : MonoBehaviour
{
    [SerializeField]
    VFXResources.VFXList deathEffect;
    [SerializeField]
    protected GameObject host = null;
    [SerializeField]
    protected bool playSounds = false;
    [SerializeField]
    [ShowIf("playSounds")]
    protected AudioSource attackSoundSource = null;

    [SerializeField]
    protected UnityEvent OnDeathAnimationDone = new UnityEvent();
    public ComboDamageTrigger OnDamageTrigger = new ComboDamageTrigger();
    public virtual void DealsDamage(int comboCount)
    {
        Debug.Log("Deals attack called - " + comboCount);
        OnDamageTrigger.Invoke(comboCount);
        if (playSounds)
        {
            var soundsSys = SoundSystem.GetInstance();
            if (soundsSys)
            {
                var clipToPlay = soundsSys.GetClip(SoundDictionary.SoundList.SwordSwing);
                attackSoundSource.clip = clipToPlay;
                attackSoundSource.Play();
            }
        }

    }
    public virtual void DeathAnimationDone()
    {
        OnDeathAnimationDone.Invoke();
        var vfxSys = VFXSystem.GetInstance();
        if (vfxSys)
        {
            if (this.host)
            {
                vfxSys.PlayEffect(deathEffect, this.host.transform.position, Quaternion.identity);
            }
        }
    }
}


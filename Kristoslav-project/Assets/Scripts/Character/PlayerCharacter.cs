using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
/// <summary>
/// The player controlled character.
/// </summary>
public class PlayerCharacter : Character
{
    [SerializeField]
    [BoxGroup("Particle Effect Group")]
    bool playHealEffect = false;
    [SerializeField]
    [ShowIf("playHealEffect")]
    [BoxGroup("Particle Effect Group")]
    [Required]
    Transform healSpawnPositon = null;
    void Start()
    {
        health = characterData.stats.health;
        stamina = characterData.stats.stamina;
    }

    public override void BeingDamage(int damage)
    {
        base.BeingDamage(damage);
    }
    public override void IncreaseHealth(float amount)
    {
        base.IncreaseHealth(amount);
        if (amount > 0)
        {
            var vfx = VFXSystem.GetInstance();
            if (vfx)
            {
                vfx.PlayEffect(VFXResources.VFXList.Heal, healSpawnPositon.position, Quaternion.Euler(90, 0, 0));
            }
        }
    }
}

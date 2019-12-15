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
    void Start()
    {
        health = characterData.stats.health;
        stamina = characterData.stats.stamina;
    }

    public override void BeingDamage(int damage)
    {
        base.BeingDamage(damage);
    }
}

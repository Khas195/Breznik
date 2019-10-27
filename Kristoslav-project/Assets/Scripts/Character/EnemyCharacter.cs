﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{
    [SerializeField]
    CharacterData enemyBaseStatsTemplate = null;

    [SerializeField]
    CharacterStatsData curStats;
    public override bool Attack()
    {
        return base.Attack();
    }

    public override void Awake()
    {
        base.Awake();
        movementBehavior.SetMovementData(enemyBaseStatsTemplate.movementData);
        curStats = GameObject.Instantiate(enemyBaseStatsTemplate.statsData);
    }

    public override void BeingDamage(float damage)
    {
        base.BeingDamage(damage);
        curStats.curHealth -= damage;
        Logger.CharacterDebug(this, " suffered " + damage + ", OUCH!! - Health Left: " + curStats.curHealth);
    }

    public override CharacterStatsData GetCharacterStats()
    {
        return curStats; 
    }

    public override bool RequestJump()
    {
        return base.RequestJump();
    }

    public override bool RequestMove(float forward, float side)
    {
        return base.RequestMove(forward, side);
    }

    public override bool RequestMovementType(IMovement.MovementType moveType)
    {
        return base.RequestMovementType(moveType);
    }
}

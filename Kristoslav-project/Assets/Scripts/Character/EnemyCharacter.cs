using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class EnemyCharacter : Character
{
    [SerializeField]
    [ReadOnly]
    CharacterStatsData curStats;
    public override bool Attack()
    {
        return base.Attack();
    }

    public override void Awake()
    {
        base.Awake();
        movementBehavior.SetMovementData(this.characterData.movementData);
        curStats = GameObject.Instantiate(this.characterData.statsData);
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

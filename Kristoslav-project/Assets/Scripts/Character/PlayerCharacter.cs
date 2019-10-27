﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// The player controlled character.
/// </summary>
public class PlayerCharacter : Character
{
    /// <summary>
    /// The player character's stats
    /// </summary>
    [Header("Character Stats Holder")]
    [SerializeField]
    CharacterData characterData = null;
    /// <summary>
    /// The camera that follow the player
    /// </summary>
    [SerializeField]
    protected Camera playerCamera = null;

    [Header("Action costs")]
    /// <summary>
    /// The cost of attack when the character play an attack animation. 
    /// </summary>
    [SerializeField]
    PlayerActionCost attackCost = null;

    /// <summary>
    /// Whether the character should regen health and stamina or not.
    /// </summary>
    bool shouldRegen = false;
    /// <summary>
    /// The cooldown timer for regening after draining health or stamina.
    /// </summary>
    Timer regenCoolDownTimer = null;
    public override void Awake()
    {
        movementBehavior.SetMovementData(characterData.movementData);
        base.Awake();
    }
    void Start()
    {
        characterData.statsData.curHealth = characterData.statsData.health;
        characterData.statsData.curStamina = characterData.statsData.stamina;
        regenCoolDownTimer = new Timer(characterData.statsData.coolDownTilRegen, StartRegen);
    }

    /// <summary>
    /// Set shouldRegen to true
    /// </summary>
    private void StartRegen()
    {
        shouldRegen = true;
    }

    public override CharacterStatsData GetCharacterStats()
    {
        return characterData.statsData;
    }

    void Update()
    {
        if (shouldRegen)
        {
            Regen();
        }
        characterData.position = this.transform.position;
        regenCoolDownTimer.Tick();
    }

    /// <summary>
    /// Regenerate the player character's stamina and health.
    /// </summary>
    private void Regen()
    {
        characterData.statsData.curHealth += characterData.statsData.healthRegenRate * Time.deltaTime;
        characterData.statsData.curStamina += characterData.statsData.staminaRegenRate * Time.deltaTime;
        if (characterData.statsData.curHealth >= characterData.statsData.health && characterData.statsData.curStamina >= characterData.statsData.stamina)
        {
            shouldRegen = false;
        }
        characterData.statsData.curHealth = Mathf.Clamp(characterData.statsData.curHealth, 0, characterData.statsData.health);
        characterData.statsData.curStamina = Mathf.Clamp(characterData.statsData.curStamina, 0, characterData.statsData.stamina);
    }

    /// <summary>
    /// Trigger the cool down of regeneration.
    /// </summary>
    private void TriggerRegenCooldown()
    {
        shouldRegen = false;
        regenCoolDownTimer.Reset();
        regenCoolDownTimer.Trigger();
    }

    public override bool RequestJump()
    {
       return base.RequestJump(); 
    }
    public override bool RequestMove(float forward, float side)
    {
        if (changeMoveTypeConditions.IsSatisfied(this) == false)
        {
            this.RequestMovementType(Movement.MovementType.Walk);
        }
        var shouldMove = true;
        if (moveConditions.IsSatisfied(this) == false) {
            forward =side = 0;
            shouldMove = false;
        }
        movementBehavior.MoveRelativeTo(forward, side, playerCamera.transform);

        return shouldMove;
    }

    public override bool Attack()
    {
        return base.Attack();
    }

    public override bool RequestMovementType(IMovement.MovementType moveType)
    {
        return base.RequestMovementType(moveType);
    }

    public override void BeingDamage(float damage)
    {
        base.BeingDamage(damage);
        this.characterData.statsData.curHealth -= damage;
        TriggerRegenCooldown();
    }
    public void OnPlayerAttack()
    {
        this.characterData.statsData.curStamina -= attackCost.cost;
        characterData.statsData.curStamina = Mathf.Clamp(characterData.statsData.curStamina, 0, characterData.statsData.stamina);
        TriggerRegenCooldown();
    }
}

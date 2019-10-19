using System;
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
    CharacterStatsData characterStats;

    [Header("Action costs")]
    /// <summary>
    /// The cost of stamina while the character is running.
    /// </summary>
    [SerializeField]
    PlayerActionCost runCost;
    /// <summary>
    /// The cost of jumping when the character signal jump
    /// </summary>
    [SerializeField]
    PlayerActionCost jumpCost;
    /// <summary>
    /// The cost of attack when the character play an attack animation. 
    /// </summary>
    [SerializeField]
    PlayerActionCost attackCost;

    /// <summary>
    /// Whether the character should regen health and stamina or not.
    /// </summary>
    bool shouldRegen = false;
    /// <summary>
    /// The cooldown timer for regening after draining health or stamina.
    /// </summary>
    Timer regenCoolDownTimer;
    void Start()
    {
        characterStats.curHealth = characterStats.health;
        characterStats.curStamina = characterStats.stamina;
        regenCoolDownTimer = new Timer(characterStats.coolDownTilRegen, StartRegen);
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
        return characterStats;
    }

    void Update()
    {
        if (shouldRegen)
        {
            Regen();
        }
        regenCoolDownTimer.Tick();
    }

    /// <summary>
    /// Regenerate the player character's stamina and health.
    /// </summary>
    private void Regen()
    {
        characterStats.curHealth += characterStats.healthRegenRate * Time.deltaTime;
        characterStats.curStamina += characterStats.staminaRegenRate * Time.deltaTime;
        if (characterStats.curHealth >= characterStats.health && characterStats.curStamina >= characterStats.stamina)
        {
            shouldRegen = false;
        }
        characterStats.curHealth = Mathf.Clamp(characterStats.curHealth, 0, characterStats.health);
        characterStats.curStamina = Mathf.Clamp(characterStats.curStamina, 0, characterStats.stamina);
    }

    /// <summary>
    /// check if the player's character is running. Then drain the stamina of the character.
    /// </summary>
    private void UpdateRunningStaminaCost()
    {
        var movement = GetMovementBehavior();
        var movementData = movement.GetMovementData();
        if (movementData.currentVelocity.magnitude >= movementData.walkSpeed && movement.GetCurrentMoveMode() == Movement.MovementType.Run)
        {
            characterStats.curStamina -= runCost.cost * Time.deltaTime;
            characterStats.curStamina = Mathf.Clamp(characterStats.curStamina, 0, characterStats.stamina);
            TriggerRegenCooldown();
        }
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
        if (base.RequestJump())
        {
            characterStats.curStamina -= jumpCost.cost;
            TriggerRegenCooldown();
            return true;
        }
        return false;
    }
    public override bool RequestMove(float forward, float side)
    {
        UpdateRunningStaminaCost();
        if (changeMoveTypeConditions.IsSatisfied(this) == false)
        {
            this.RequestMovementType(Movement.MovementType.Walk);
        }
        return base.RequestMove(forward, side);
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
        this.characterStats.curHealth -= damage;
        TriggerRegenCooldown();
    }
}

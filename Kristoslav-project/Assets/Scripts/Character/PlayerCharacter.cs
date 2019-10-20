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
    CharacterData characterData;

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
    /// check if the player's character is running. Then drain the stamina of the character.
    /// </summary>
    private void UpdateRunningStaminaCost()
    {
        var movement = GetMovementBehavior();
        var movementData = movement.GetMovementData();
        if (movementData.currentVelocity.magnitude >= movementData.walkSpeed && movement.GetCurrentMoveMode() == Movement.MovementType.Run)
        {
            characterData.statsData.curStamina -= runCost.cost * Time.deltaTime;
            characterData.statsData.curStamina = Mathf.Clamp(characterData.statsData.curStamina, 0, characterData.statsData.stamina);
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
            characterData.statsData.curStamina -= jumpCost.cost;
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
        this.characterData.statsData.curHealth -= damage;
        TriggerRegenCooldown();
    }
    public void OnPlayerAttack() {
        this.characterData.statsData.curStamina -= attackCost.cost;
        characterData.statsData.curStamina = Mathf.Clamp(characterData.statsData.curStamina, 0, characterData.statsData.stamina);
        TriggerRegenCooldown();
    }
}

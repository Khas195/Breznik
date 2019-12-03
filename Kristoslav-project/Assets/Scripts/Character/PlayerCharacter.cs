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

    /// <summary>
    /// Whether the character should regen health and stamina or not.
    /// </summary>
    bool shouldRegen = false;



    /// <summary>
    /// The cooldown timer for regening after draining health or stamina.
    /// </summary>
    Timer regenCoolDownTimer = null;
    void Start()
    {
        health = characterData.stats.health;
        stamina = characterData.stats.stamina;
        regenCoolDownTimer = new Timer(characterData.stats.coolDownTilRegen, StartRegen);
    }
    /// <summary>
    /// Set shouldRegen to true
    /// </summary>
    private void StartRegen()
    {
        shouldRegen = true;
    }

    protected override void Update()
    {
        base.Update();
        if (shouldRegen)
        {
            Regen();
        }
        regenCoolDownTimer.Tick();
        if (Input.GetKeyDown(KeyCode.N))
        {
            BeingDamage(1000);
        }
    }

    /// <summary>
    /// Regenerate the player character's stamina and health.
    /// </summary>
    private void Regen()
    {
        health += characterData.stats.healthRegenRate * Time.deltaTime;
        stamina += characterData.stats.staminaRegenRate * Time.deltaTime;
        if (health >= characterData.stats.health && stamina >= characterData.stats.stamina)
        {
            shouldRegen = false;
        }
        health = Mathf.Clamp(health, 0, characterData.stats.health);
        stamina = Mathf.Clamp(stamina, 0, characterData.stats.stamina);
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
    public override void BeingDamage(int damage)
    {
        base.BeingDamage(damage);
        TriggerRegenCooldown();
    }
    public void OnPlayerAttack()
    {
        TriggerRegenCooldown();
    }
}

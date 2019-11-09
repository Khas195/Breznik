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
    /// The camera that follow the player
    /// </summary>
    [SerializeField]
    [BoxGroup("Requirements")]
    protected Camera playerCamera = null;
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
    public override void BeingDamage(float damage)
    {
        base.BeingDamage(damage);
        TriggerRegenCooldown();
    }
    public void OnPlayerAttack()
    {
        TriggerRegenCooldown();
    }
}

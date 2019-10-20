using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handle the health bar and stamina of the character based on the character stats data.
/// </summary>
public class PlayerStatsUI : MonoBehaviour
{
    /// <summary>
    /// The health bar of the character.
    /// </summary>
    [SerializeField]
    Slider healthBar;
    /// <summary>
    /// The Stamina bar of the character.
    /// </summary>
    [SerializeField]
    Slider staminaBar;
    /// <summary>
    /// The character stats data of the character
    /// </summary>
    [SerializeField]
    CharacterData data;

    // Update is called once per frame
    void Update()
    {
        var targetHealthValue= data.statsData.curHealth/data.statsData.health;
        var targetStaminaValue = data.statsData. curStamina/data.statsData.stamina;

        healthBar.value = Mathf.Lerp(healthBar.value, targetHealthValue, 0.1f);
        staminaBar.value = Mathf.Lerp(staminaBar.value, targetStaminaValue, 0.1f);
    }
}

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
    FlexibleUIStatsBar healthBar = null;
    /// <summary>
    /// The Stamina bar of the character.
    /// </summary>
    [SerializeField]
    FlexibleUIDotsBar staminaDots = null;
    /// <summary>
    /// The character stats data of the character
    /// </summary>
    [SerializeField]
    CharacterData data = null;

    // Update is called once per frame
    void Update()
    {
        var targetHealthValue= data.statsData.curHealth/data.statsData.health;
        var targetStaminaValue = data.statsData. curStamina/data.statsData.stamina;

        var curHealthValue = healthBar.GetFilledAmount();

        curHealthValue  = Mathf.Lerp(curHealthValue, targetHealthValue, 0.1f);

        healthBar.SetFilledAmount(curHealthValue);
        staminaDots.SetFilledAmount(targetStaminaValue);
    }
}

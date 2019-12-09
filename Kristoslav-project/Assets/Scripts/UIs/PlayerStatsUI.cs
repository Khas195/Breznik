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
    FlexibleUIDotsBar healthBar = null;
    /// <summary>
    /// The character stats data of the character
    /// </summary>
    [SerializeField]
    CharacterStatsData baseStats = null;
    [SerializeField]
    Character player = null;

    // Update is called once per frame
    void Update()
    {
        var targetHealthValue = player.GetHealth() / baseStats.health;

        healthBar.SetFilledAmount(targetHealthValue);
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStatsData", menuName = "Data/Stats", order = 1)]
public class CharacterStatsData : ScriptableObject {
    public int health;
    public int healthRegenRate;

    public int stamina;
    public int staminaRegenRate;

    public float coolDownTilRegen;
}


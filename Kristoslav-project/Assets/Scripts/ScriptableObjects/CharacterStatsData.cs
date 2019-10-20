using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStatsData", menuName = "Data/Stats", order = 1)]
public class CharacterStatsData : ScriptableObject {
    public float health;
    public float curHealth;
    public float healthRegenRate;

    public float stamina;
    public float curStamina;
    public float staminaRegenRate;

    public float coolDownTilRegen;
    public float attackCooldown;
}


using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStatsData", menuName = "Data/Stats", order = 1)]
public class CharacterStatsData : ScriptableObject
{
    public int health;
    public int healthReturnOnDeath;

    public int stamina;

}


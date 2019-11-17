using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Data/Character", order = 1)]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public CharacterStatsData stats;
    public MovementData movementData;

    public float rotateSpeed;
    public bool isNPC = false;
    [ShowIf("isNPC")]
    public float aggroRange = 20f;
    [ShowIf("isNPC")]
    public float stoppingDistance = 3f;

    [ShowIf("isNPC")]
    public float attackRange = 4f;
}

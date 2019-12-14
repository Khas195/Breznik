using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Data/Character", order = 1)]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public CharacterStatsData stats;
    public MovementData movementData;

    public float rotateSpeed;
    public float attackRange = 4f;
    public float reachRange = 0;
    public int attackDamage = 5;
    public bool isNPC = false;

    public LayerMask enemiesMask;

    [ShowIf("isNPC")]
    public float aggroRange = 20f;
    [ShowIf("isNPC")]
    public float stoppingDistance = 3f;
}

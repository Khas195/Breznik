using UnityEngine;

[CreateAssetMenu(fileName ="CharacterData", menuName ="Data/Character", order = 1)]
public class CharacterData : ScriptableObject {
    public string characterName;
    public CharacterStatsData stats;
    public MovementData movementData;

    public float rotateSpeed;
    
    public Vector3 cameraPos;
}

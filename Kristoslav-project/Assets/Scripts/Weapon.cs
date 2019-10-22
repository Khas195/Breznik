using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    float damage;
    [SerializeField]
    GameObject wielder;

    bool isAttacking;

    GameObject currentVictim = null;

    void OnTriggerEnter(Collider other)
    {
        var otherObject= other.gameObject;
        if (otherObject != wielder){
            var character = otherObject.GetComponentInChildren<Character>();
            if (character && currentVictim != otherObject) {
                currentVictim = otherObject;
                var wielderCharacter = otherObject.GetComponentInChildren<Character>();
                if (wielderCharacter.GetCharacterAnimator().IsInAttackingAnimation()) {
                    Definition.CharacterDebug(wielder.GetComponentInChildren<Character>(), " had striked " + character);
                    character.BeingDamage(damage);
                }
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == currentVictim) {
            currentVictim = null;
        }
    }
    
}

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

    void OnTriggerEnter(Collider other)
    {
        var otherObject= other.gameObject;
        if (otherObject != wielder){
            var character = otherObject.GetComponentInChildren<Character>();
            if (character) {

                var wielderCharacter = otherObject.GetComponentInChildren<Character>();
                if (wielderCharacter.GetCharacterAnimator().IsInAttackingAnimation()) {
                    Definition.CharacterDebug(wielder.GetComponentInChildren<Character>(), " had striked " + character);
                    character.BeingDamage(damage);
                }
            }
        }
    }
    
}

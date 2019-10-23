using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    float damage;
    [SerializeField]
    GameObject wielder;


    GameObject currentVictim = null;
    Character wielderChar;
    void Start()
    {
        wielderChar = wielder.GetComponentInChildren<Character>();

    }

    void OnTriggerEnter(Collider other)
    {
        Definition.CharacterDebug(wielderChar, "Character's weapon touched something");
        var otherObject = other.gameObject;
        if (otherObject != wielder)
        {
            Definition.CharacterDebug(wielderChar, "Character's weapon didnt touch himself.");
            var character = otherObject.GetComponentInChildren<Character>();
            if (character)
            {
                Definition.CharacterDebug(wielderChar, "Character's weapon touched a different character - " + character);
                if (wielderChar.GetCharacterAnimator().IsInAttackingAnimation())
                {
                    Definition.CharacterDebug(wielder.GetComponentInChildren<Character>(), "'s weapon had striked " + character);
                    character.BeingDamage(damage);
                }
            }
        }
    }
    
}

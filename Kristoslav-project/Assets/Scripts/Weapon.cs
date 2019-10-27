using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    float damage = 0;
    [SerializeField]
    GameObject wielder = null;
    [SerializeField]
    PhysicCallBack killBox = null;
    [SerializeField]
    Character wielderChar = null;
    void Start()
    {
        wielderChar = wielder.GetComponentInChildren<Character>();
        killBox.triggerEnter.AddListener(OnKillBoxEnter);
    }
    public void SwitchKillBox(bool isOn) {
        killBox.gameObject.SetActive(isOn);
    }
    public void OnKillBoxEnter(Collider other)
    {
        Logger.CharacterDebug(wielderChar, "Character's weapon touched something");

        var otherObject = other.gameObject;
        if (otherObject != wielder)
        {
            Logger.CharacterDebug(wielderChar, "Character's weapon didnt touch himself.");
            var character = otherObject.GetComponentInChildren<Character>();
            if (character)
            {
                Logger.CharacterDebug(wielderChar, "Character's weapon touched a different character - " + character);
                if (wielderChar.GetCharacterAnimator().IsInAttackingAnimation())
                {
                    Logger.CharacterDebug(wielder.GetComponentInChildren<Character>(), "'s weapon had striked " + character);
                    character.BeingDamage(damage);
                }
            }
        }
    }
}

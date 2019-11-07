using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    float damage = 0;
    [SerializeField]
    GameObject wielder = null;
    [SerializeField]
    Character wielderChar = null;
    [SerializeField]
    List<Collider> hitboxes;

    void Start()
    {
        wielderChar = wielder.GetComponentInChildren<Character>();
    }
    public void DealsDamage(int hitBoxIndex)
    {
        Debug.Log("Deals attack called - Hit Box" + hitBoxIndex);
        if (hitBoxIndex < 1 || hitBoxIndex > hitboxes.Count) return;
        var targetHitBoxes = hitboxes[hitBoxIndex-1];
        Collider[] cols = Physics.OverlapBox(targetHitBoxes.bounds.center, targetHitBoxes.bounds.extents,
         targetHitBoxes.transform.rotation, LayerMask.GetMask("HitBox"));
        foreach (var col in cols)
        {
            TryToDealsDamage(col);
        }
    }
    public bool TryToDealsDamage(Collider targetCollider)
    {
        Logger.CharacterDebug(wielderChar, "Character's weapon left something");

        var otherObject = targetCollider.gameObject;
        if (otherObject != wielder)
        {
            Logger.CharacterDebug(wielderChar, "Character's weapon didnt left himself.");
            var character = otherObject.GetComponentInChildren<Character>();
            if (character)
            {
                Logger.CharacterDebug(wielder.GetComponentInChildren<Character>(), "'s weapon had striked " + character);
                character.BeingDamage(damage);
                return true;
            }
        }
        return false;
    }
}

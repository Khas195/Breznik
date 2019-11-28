using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    public UnityEvent OnWeaponHit = new UnityEvent();
    [SerializeField]
    int damage = 0;
    [SerializeField]
    GameObject wielder = null;
    [SerializeField]
    Character wielderChar = null;
    [SerializeField]
    List<Collider> hitboxes = new List<Collider>();
    [SerializeField]
    GameObject swordEdge;
    [SerializeField]
    LayerMask attackableMasks;

    void Start()
    {
        wielderChar = wielder.GetComponentInChildren<Character>();
    }
    public void DealsDamage(int hitBoxIndex)
    {
        Debug.Log("Deals attack called - Hit Box" + hitBoxIndex);
        if (hitBoxIndex < 1 || hitBoxIndex > hitboxes.Count) return;
        var targetHitBoxes = hitboxes[hitBoxIndex - 1];
        Collider[] cols = Physics.OverlapBox(targetHitBoxes.bounds.center, targetHitBoxes.bounds.extents,
         targetHitBoxes.transform.rotation, attackableMasks);
        foreach (var col in cols)
        {
            TryToDealsDamage(col);
        }
    }
    public bool TryToDealsDamage(Collider targetCollider)
    {
        Logger.CharacterDebug(wielderChar, "Character's weapon touch something");

        var otherObject = targetCollider.gameObject;
        if (otherObject != wielder)
        {
            Logger.CharacterDebug(wielderChar, "Character's weapon didnt touch himself.");
            var character = otherObject.GetComponentInChildren<Character>();
            if (character && character.IsAlive())
            {
                Logger.CharacterDebug(wielder.GetComponentInChildren<Character>(), "'s weapon had striked " + character);
                VFXSystem.GetInstance().SpawnHit(targetCollider.ClosestPointOnBounds(swordEdge.transform.position), 5f);
                VFXSystem.GetInstance().SpawnBlood(targetCollider.ClosestPointOnBounds(swordEdge.transform.position), 5f);
                OnWeaponHit.Invoke();
                character.BeingDamage(damage);
                return true;
            }
        }
        return false;
    }
}

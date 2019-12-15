using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;
public class Weapon : MonoBehaviour
{
    public UnityEvent OnWeaponHit = new UnityEvent();
    [SerializeField]
    protected Character wielderChar = null;
    [SerializeField]
    protected List<Collider> hitboxes = new List<Collider>();
    [SerializeField]
    [ReadOnly]
    protected LayerMask attackableMasks;


    [SerializeField]
    [ReadOnly]
    protected int damage = 0;

    [SerializeField]
    [ReadOnly]
    protected GameObject wielder = null;
    protected virtual void Start()
    {
        wielder = wielderChar.GetHost();
        damage = wielderChar.GetCharacterDataPack().attackDamage;
        attackableMasks = wielderChar.GetCharacterDataPack().enemiesMask;
    }
    public virtual void DealsDamage(int hitBoxIndex)
    {
        Debug.Log("Deals attack called - Hit Box" + hitBoxIndex);
        if (hitBoxIndex < 0 || hitBoxIndex >= hitboxes.Count) return;
        var targetHitBoxes = hitboxes[hitBoxIndex];
        Collider[] cols = Physics.OverlapBox(targetHitBoxes.bounds.center, targetHitBoxes.bounds.extents,
         targetHitBoxes.transform.rotation, attackableMasks);
        foreach (var col in cols)
        {
            TryToDealsDamage(col);
        }
    }
    public virtual bool TryToDealsDamage(Collider targetCollider)
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
                OnWeaponHit.Invoke();
                character.BeingDamage(damage);
                if (character.GetHealth() <= 0)
                {
                    wielder.GetComponentInChildren<Character>().IncreaseHealth(character.GetCharacterDataPack().stats.healthReturnOnDeath);
                }
                return true;
            }
        }
        return false;
    }
}

using UnityEngine;

public class WoodenSword : Weapon
{
    [SerializeField]
    Transform particleSpawnPosition;
    public override bool TryToDealsDamage(UnityEngine.Collider targetCollider)
    {
        if (base.TryToDealsDamage(targetCollider) == false) return false;
        var vfxSystem = VFXSystem.GetInstance();
        if (vfxSystem)
        {
            vfxSystem.PlayEffect(VFXResources.VFXList.SwordHitEnemy, particleSpawnPosition.position, Quaternion.identity);
        }

        return true;
    }
}

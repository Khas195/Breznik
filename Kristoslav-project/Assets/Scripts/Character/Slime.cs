
using NaughtyAttributes;
using UnityEngine;
/// <summary>
/// The Character class handles all the possible behavior that a character can have.
///It's handle the character's behaviors by calling the appropriate behavior.
/// </summary>
public class Slime : Character
{
    [SerializeField]
    [BoxGroup("Slime Specific")]
    Transform slimeHitSpawnPoint = null;
    public override void BeingDamage(int damage)
    {
        base.BeingDamage(damage);
        if (slimeHitSpawnPoint != null)
        {
            var vfx = VFXSystem.GetInstance();
            if (vfx)
            {
                vfx.PlayEffect(VFXResources.VFXList.SwordHitSlime, slimeHitSpawnPoint.position, Quaternion.identity);
            }
        }
    }
}


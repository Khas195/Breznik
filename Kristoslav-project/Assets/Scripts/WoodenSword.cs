using UnityEngine;

public class WoodenSword : Weapon
{
    [SerializeField]
    Transform particleSpawnPosition = null;
    [SerializeField]
    AudioSource swordHitSources = null;

    public override bool TryToDealsDamage(UnityEngine.Collider targetCollider)
    {
        if (base.TryToDealsDamage(targetCollider) == false) return false;
        var vfxSystem = VFXSystem.GetInstance();
        if (vfxSystem)
        {
            vfxSystem.PlayEffect(VFXResources.VFXList.SwordHitEnemy, particleSpawnPosition.position, Quaternion.identity);
        }

        var soundSystem = SoundSystem.GetInstance();
        if (soundSystem)
        {
            AudioClip clipToPlay = null;
            if (targetCollider.tag == "Slime")
            {
                clipToPlay = soundSystem.GetClip(SoundDictionary.SoundList.SwordHitSlime);
            }
            else if (targetCollider.tag == "Chicken")
            {
                clipToPlay = soundSystem.GetClip(SoundDictionary.SoundList.SwordHitChicken);
            }
            swordHitSources.clip = clipToPlay;
            swordHitSources.Play();
        }
        return true;
    }
}

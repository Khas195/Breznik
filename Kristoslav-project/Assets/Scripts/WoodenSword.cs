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
            PlayHitVFX(targetCollider, vfxSystem);
        }

        var soundSystem = SoundSystem.GetInstance();
        if (soundSystem)
        {
            PlayHitSound(targetCollider, soundSystem);
        }
        return true;
    }

    private void PlayHitVFX(Collider targetCollider, VFXSystem vfxSystem)
    {
        if (targetCollider.tag == "Slime")
        {
            vfxSystem.PlayEffect(VFXResources.VFXList.SwordHitSlime, particleSpawnPosition.position, Quaternion.identity);
        }
        else if (targetCollider.tag == "Chicken")
        {
            vfxSystem.PlayEffect(VFXResources.VFXList.SwordHitChicken, particleSpawnPosition.position, Quaternion.identity);
        }
        else if (targetCollider.tag == "Crab")
        {
            vfxSystem.PlayEffect(VFXResources.VFXList.SwordHitCrab, particleSpawnPosition.position, Quaternion.identity);
        }
    }

    private void PlayHitSound(Collider targetCollider, SoundSystem soundSystem)
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
        else if (targetCollider.tag == "Crab")
        {
            clipToPlay = soundSystem.GetClip(SoundDictionary.SoundList.SwordHitCrab);
        }
        swordHitSources.clip = clipToPlay;
        swordHitSources.Play();
    }
}

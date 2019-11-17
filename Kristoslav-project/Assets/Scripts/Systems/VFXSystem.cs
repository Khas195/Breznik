using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Experimental scripts for spawning fire vfxxxx
/// </summary>
public class VFXSystem : SingletonMonobehavior<VFXSystem>
{
    [SerializeField]
    GameObject randomDeathVFX = null;
    [SerializeField]
    GameObject attackHitVFX = null;
    [SerializeField]
    GameObject beingDamageVFX = null;
    protected override void Awake()
    {
        base.Awake();
    }

    public void SpawnDeath(Vector3 location, float time)
    {
        var targetVFx = GameObject.Instantiate(randomDeathVFX, location, Quaternion.identity);
        StartCoroutine(DeleteVFX(targetVFx, time));
    }
    IEnumerator DeleteVFX(GameObject vfxToDelete, float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(vfxToDelete);
    }

    public void SpawnHit(Vector3 location, float time)
    {
        var targetVFx = GameObject.Instantiate(attackHitVFX, location, Quaternion.identity);
        StartCoroutine(DeleteVFX(targetVFx, time));


    }

    public void SpawnBlood(Vector3 location, float time)
    {
        var targetVFx = GameObject.Instantiate(beingDamageVFX, location, Quaternion.identity);
        StartCoroutine(DeleteVFX(targetVFx, time));

    }
}

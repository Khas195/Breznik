using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class FootStepEffectController : MonoBehaviour
{
    [SerializeField]
    [Required]
    [BoxGroup("Requirement")]
    Transform leftFootTrans = null;
    [SerializeField]
    [Required]
    [BoxGroup("Requirement")]
    Transform rightFootTrans = null;
    [SerializeField]
    [BoxGroup("Requirement")]
    float physicCheckSize = 5f;
    [SerializeField]
    LayerMask walkableMask;

    [SerializeField]
    bool hasSounds = false;
    [SerializeField]
    [ShowIf("hasSounds")]
    AudioSource footSource = null;


    bool leftFootPlayed = false;
    bool rightFootPlayed = false;
    private void OnDrawGizmos()
    {
        if (leftFootTrans)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(leftFootTrans.position, physicCheckSize);
        }
        if (rightFootTrans)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(rightFootTrans.position, physicCheckSize);
        }
    }
    private void FixedUpdate()
    {
        bool shouldPlayLeftFoot = false;
        bool shouldPlayRightFoot = false;

        bool leftFootTouchGround = IsFootTouchGround(leftFootTrans.position);
        if (leftFootTouchGround)
        {
            if (leftFootPlayed == false)
            {
                shouldPlayLeftFoot = true;
            }
        }
        else
        {
            leftFootPlayed = false;
        }

        bool rightFootTouchGround = IsFootTouchGround(rightFootTrans.position);
        if (rightFootTouchGround)
        {
            if (rightFootPlayed == false)
            {
                shouldPlayRightFoot = true;
            }
        }
        else
        {
            rightFootPlayed = false;
        }

        if (leftFootTouchGround != rightFootTouchGround)
        {
            if (shouldPlayLeftFoot)
            {
                PlayFootEffect(leftFootTrans.position);
                PlayFootSound();
                leftFootPlayed = true;
            }
            else if (shouldPlayRightFoot)
            {
                PlayFootEffect(rightFootTrans.position);
                PlayFootSound();
                rightFootPlayed = true;
            }
        }

    }

    private void PlayFootSound()
    {
        var soundsSys = SoundSystem.GetInstance();
        if (soundsSys)
        {
            var clipToPlay = soundsSys.GetClip(SoundDictionary.SoundList.FootFall);
            footSource.clip = clipToPlay;
            footSource.Play();
        }
    }

    private void PlayFootEffect(Vector3 footPos)
    {
        var vfx = VFXSystem.GetInstance();
        if (vfx)
        {
            vfx.PlayEffect(VFXResources.VFXList.FootFall, footPos, Quaternion.identity);
        }
    }

    private bool IsFootTouchGround(Vector3 footPosition)
    {
        var cols = Physics.OverlapSphere(footPosition, physicCheckSize, walkableMask);
        return cols.Length > 0;
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundsMusic", menuName = "SoundsMusic", order = 0)]
public class SoundDictionary : ScriptableObject
{
    public enum SoundList
    {
        FootFall,
        SwordHitSlime,
        SwordSwing,
        SlimeRandom,
        SwordHitChicken,
        ChickenStartChasing,
        chickenAttack,
        chickenFootFall,
        CrabHeavyAttack,
        CrabFootFall
    }
    [Serializable]
    public struct SoundResources
    {
        public SoundList tag;
        public List<AudioClip> clips;
    }
    [SerializeField]
    public List<SoundResources> resourcesList = new List<SoundResources>();
}

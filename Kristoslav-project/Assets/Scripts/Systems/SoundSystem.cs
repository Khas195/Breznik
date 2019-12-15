using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
public class SoundSystem : SingletonMonobehavior<SoundSystem>
{
    [SerializeField]
    [Required]
    SoundDictionary soundDictionary = null;
    protected override void Awake()
    {
        base.Awake();
    }
    public AudioClip GetClip(SoundDictionary.SoundList clipTag)
    {
        foreach (var item in soundDictionary.resourcesList)
        {
            if (item.tag == clipTag)
            {
                var randomClip = Random.Range(0, item.clips.Count);
                return item.clips[randomClip];
            }
        }
        return null;
    }
}

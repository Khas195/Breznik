using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundRandomly : MonoBehaviour
{
    [SerializeField]
    float interval = 1;
    [SerializeField]
    SoundDictionary.SoundList soundsTag;
    [SerializeField]
    AudioSource source = null;

    float curTime = 0;
    // Update is called once per frame
    void Update()
    {
        if (source.isPlaying == false)
        {
            if (curTime >= interval)
            {
                var soundSystem = SoundSystem.GetInstance();
                if (soundSystem)
                {
                    var clipToPlay = soundSystem.GetClip(soundsTag);
                    source.clip = clipToPlay;
                    source.Play();
                }
                curTime = 0;
            }
            curTime += Time.deltaTime;

        }
    }
}

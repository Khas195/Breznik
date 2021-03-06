using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
public class SoundSystem : SingletonMonobehavior<SoundSystem>
{
    [SerializeField]
    [Required]
    SoundDictionary soundDictionary = null;
    [SerializeField]
    AudioSource backgroundSource = null;
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
    void Update()
    {
        if (backgroundSource.isPlaying == false)
        {
            var randomSong = Random.Range(0, soundDictionary.backgroundMusic.Count);
            backgroundSource.clip = soundDictionary.backgroundMusic[randomSong];
            Debug.Log("New Song : " + backgroundSource.clip.name + " randomed as " + randomSong);
            if (GameMaster.GetInstance().GetCurrentGameState().GetState() == GameState.States.InGame)
            {
                PlayBackGroundMusic();
            }
        }
    }
    public void PlayBackGroundMusic()
    {
        backgroundSource.Play();
        backgroundSource.enabled = true;
    }
    public void StopBackGroundMusic()
    {
        backgroundSource.Stop();
        backgroundSource.enabled = false;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneSystem : SingletonMonobehavior<CutsceneSystem>
{
    [SerializeField]
    List<Animator> cutscenes = new List<Animator>();
    int cutsceneIndex = 0;

    public void PlayNext()
    {
        cutscenes[cutsceneIndex].SetTrigger("Play");
    }
}

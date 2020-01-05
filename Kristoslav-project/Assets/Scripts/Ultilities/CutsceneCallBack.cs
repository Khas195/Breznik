using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CutsceneCallBack : MonoBehaviour
{
    [SerializeField]
    UnityEvent onCutsceneDone;
    [SerializeField]
    UnityEvent onCutsceneStart;

    public void OnCutsceneDone()
    {
        onCutsceneDone.Invoke();
    }
    public void OnCutsceneStart()
    {
        onCutsceneStart.Invoke();
    }
}

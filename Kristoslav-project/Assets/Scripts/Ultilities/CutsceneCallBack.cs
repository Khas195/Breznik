using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CutsceneCallBack : MonoBehaviour
{
    [SerializeField]
    UnityEvent onCutsceneDone;

    public void OnCutsceneDone()
    {
        onCutsceneDone.Invoke();
    }
}

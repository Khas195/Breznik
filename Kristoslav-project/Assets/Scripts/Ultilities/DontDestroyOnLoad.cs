using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script keep the parent game object and its children from being destroy when loading scene.
/// </summary>
public class DontDestroyOnLoad : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}

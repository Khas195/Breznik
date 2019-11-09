using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraEntity : SingletonMonobehavior<MainCameraEntity>
{

    [SerializeField]
    GameObject host = null;

    public GameObject GetHost() {
        return host;
    }

    protected override void Awake()
    {
        base.Awake();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraEntity : MonoBehaviour
{

    [SerializeField]
    GameObject host = null;

    public GameObject GetHost()
    {
        return host;
    }
    void Start()
    {
        EntitiesMaster.GetInstance().RegisterEntity(EntitiesMaster.EntitiesKey.PLAYERCAMERA, host);
    }
}

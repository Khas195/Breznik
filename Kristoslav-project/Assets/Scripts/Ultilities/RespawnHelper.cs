using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnHelper : MonoBehaviour
{
    [SerializeField]
    DeadZone zone = null;
    [SerializeField]
    GameObject host = null;

    public void Respawn()
    {
        var pos = zone.GetRespawnPosition();
        host.transform.position = pos;
    }
}

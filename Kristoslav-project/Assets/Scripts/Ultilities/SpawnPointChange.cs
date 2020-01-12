using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointChange : MonoBehaviour
{
    [SerializeField]
    DeadZone zone;
    [SerializeField]
    int spawnPointToChangeTo = 0;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            zone.SetNewSpawnPoint(spawnPointToChangeTo);
        }
    }
}

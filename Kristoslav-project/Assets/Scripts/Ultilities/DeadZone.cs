using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField]
    List<Transform> respawnPoint = new List<Transform>();
    int currentSpawnPoint = 0;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = respawnPoint[currentSpawnPoint].transform.position;
        }
    }
    public Vector3 GetRespawnPosition()
    {
        return respawnPoint[currentSpawnPoint].transform.position;
    }
    public void SetNewSpawnPoint(int spawnPointToChangeTo)
    {
        currentSpawnPoint = spawnPointToChangeTo;
    }
}

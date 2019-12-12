using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.AI;


public class Area : MonoBehaviour
{
    [SerializeField]
    [Required]
    AreaData data = null;
    [SerializeField]
    [Required]
    GameObject host = null;
    [SerializeField]
    List<Transform> spawnPoints = new List<Transform>();

    [SerializeField]
    [ReadOnly]
    List<NPCController> aiControllers = new List<NPCController>();



    [SerializeField]
    [ReadOnly]
    List<NPCController> deactivatedAiControllers = new List<NPCController>();



    [SerializeField]
    float spawnRate = 1f;
    [SerializeField]
    bool shouldSpawn = true;


    Bounds boundBox = new Bounds();
    float curTime = 0.0f;
    void Start()
    {
        boundBox = new Bounds(host.transform.position, new Vector3(data.size, data.size, data.size));
    }
    void OnDrawGizmos()
    {
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(spawnPoints[i].position, 1f);
        }

        var spawnAreaColor = Color.magenta;
        spawnAreaColor.a = 0.2f;
        Gizmos.color = spawnAreaColor;
        var boundingBox = new Bounds(host.transform.position, new Vector3(data.size, 1, data.size));
        Gizmos.DrawCube(boundingBox.center, boundingBox.extents * 2f);
    }

    public void SetShouldSpawn(bool spawn)
    {
        shouldSpawn = spawn;
    }

    void Update()
    {
        if (shouldSpawn)
        {
            if (curTime >= spawnRate)
            {
                if (aiControllers.Count < data.maxPopulation)
                {
                    SpawnRandomMob();
                }
                else
                {
                    shouldSpawn = false;
                }
                curTime = 0;
            }
            curTime += Time.deltaTime;
        }

    }
    private void SpawnRandomMob()
    {
        if (deactivatedAiControllers.Count <= 0)
        {
            GameObject mobPrefab = ChooseRandomMob();
            CreateMobFromPrefab(mobPrefab);
        }
        else
        {
            var mobToRevive = deactivatedAiControllers[0];
            var gameObjectHost = mobToRevive.GetHost();
            gameObjectHost.transform.position = RandomSpawnPointInArea();
            mobToRevive.Revive();
        }
    }

    private GameObject ChooseRandomMob()
    {
        var randomValue = UnityEngine.Random.value;

        var inhabitantRatioToSpawn = data.typeOfInhabitants[0];
        var curValue = 0.0f;
        foreach (var inhabitantRatio in data.typeOfInhabitants)
        {
            curValue += inhabitantRatio.ratio;
            if (randomValue <= curValue)
            {
                inhabitantRatioToSpawn = inhabitantRatio;
                break;
            }
        }

        return inhabitantRatioToSpawn.inhabitant;
    }

    private void CreateMobFromPrefab(GameObject mobPrefab)
    {
        var randomPos = RandomSpawnPointInArea();
        var newInhabitant = GameObject.Instantiate(mobPrefab, randomPos, Quaternion.identity, this.transform);
        var npcControl = newInhabitant.GetComponentInChildren<NPCController>();
        var collider = newInhabitant.GetComponentInChildren<Collider>(true);
        if (collider != null)
        {
            collider.enabled = true;
        }
        if (npcControl)
        {
            aiControllers.Add(npcControl);
            npcControl.SetHome(this);
            npcControl.SetAiActive(true);
        }
    }
    public Bounds GetBoundBox()
    {
        return this.boundBox;
    }
    public Vector3 RandomSpawnPointInArea()
    {
        int randomPosIndex = UnityEngine.Random.Range(0, spawnPoints.Count);
        NavMeshHit hit;
        NavMesh.SamplePosition(spawnPoints[randomPosIndex].position, out hit, 100, NavMesh.AllAreas);
        return hit.position;
    }

    public Vector3 RandomPointInArea()
    {
        Vector3 randomPointInBox = Vector3.zero;
        randomPointInBox.x = UnityEngine.Random.Range(boundBox.center.x - boundBox.extents.x, boundBox.center.x + boundBox.extents.x);
        randomPointInBox.y = UnityEngine.Random.Range(boundBox.center.y - boundBox.extents.y, boundBox.center.y + boundBox.extents.y);
        randomPointInBox.z = UnityEngine.Random.Range(boundBox.center.z - boundBox.extents.z, boundBox.center.z + boundBox.extents.z);
        NavMeshHit hit;
        NavMesh.SamplePosition(randomPointInBox, out hit, 100f, NavMesh.AllAreas);
        return hit.position;
    }
    public void RemoveFromActiveList(NPCController target)
    {
        if (aiControllers.Contains(target))
        {
            aiControllers.Remove(target);
            if (deactivatedAiControllers.Contains(target) == false)
            {
                deactivatedAiControllers.Add(target);
            }
        }
    }
    public void AddToActiveList(NPCController target)
    {
        if (deactivatedAiControllers.Contains(target))
        {
            deactivatedAiControllers.Remove(target);
            if (aiControllers.Contains(target) == false)
            {
                aiControllers.Add(target);
            }
        }
    }
    public bool IsInArea(Vector3 position)
    {
        return boundBox.Contains(position);
    }
    public GameObject GetHost()
    {
        return host;
    }
}

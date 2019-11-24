using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Area : MonoBehaviour
{
    [SerializeField]
    AreaData data;
    [SerializeField]
    List<NPCController> nPCs;
    [SerializeField]
    GameObject center;
    List<GameObject> currentInhabitants = new List<GameObject>();
    void Start()
    {
        PopulateArea();
    }
    void OnDrawGizmos()
    {
        if (data)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(center.transform.position, data.size);
        }
    }

    private void PopulateArea()
    {
        foreach (var inhabitantRatio in data.typeOfInhabitants)
        {
            int amountToSpawn = Mathf.FloorToInt(inhabitantRatio.ratio * data.maxPopulation);
            for (int i = 0; i < amountToSpawn; i++)
            {
                var randomPos = RandomPointInArea();
                var newInhabitant = GameObject.Instantiate(inhabitantRatio.inhabitant, randomPos, Quaternion.identity, this.transform);
                currentInhabitants.Add(newInhabitant);
            }

        }
    }

    private Vector3 RandomPointInArea()
    {
        Vector3 randomPos = (UnityEngine.Random.insideUnitSphere * data.size) + center.transform.position;
        float baseRange = 5f;
        NavMeshHit hit;
        while ((NavMesh.SamplePosition(randomPos, out hit, baseRange, NavMesh.AllAreas) == false))
        {
            baseRange += 5f;
        }
        return hit.position;
    }
}

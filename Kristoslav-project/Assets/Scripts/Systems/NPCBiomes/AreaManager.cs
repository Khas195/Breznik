using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    public List<Area> areas = new List<Area>();
    void FixedUpdate()
    {
        for (int i = 0; i < areas.Count; i++)
        {
            var boundBox = areas[i].GetBoundBox();

            Collider[] cols = Physics.OverlapBox(areas[i].GetHost().transform.position, boundBox.extents, Quaternion.identity);
            foreach (var col in cols)
            {
                if (col.tag == "Player")
                {
                    AllowSpawnExcept(areas[i]);
                    break;
                }
            }
        }
    }

    private void AllowSpawnExcept(Area exception)
    {
        for (int i = 0; i < areas.Count; i++)
        {
            if (areas[i] != exception)
            {
                areas[i].SetShouldSpawn(true);
            }
        }
    }
}

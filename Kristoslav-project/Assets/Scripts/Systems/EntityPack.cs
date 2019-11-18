using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EntityPack
{
    public EntitiesMaster.EntitiesKey key;
    public GameObject gameObject;

    public EntityPack(EntitiesMaster.EntitiesKey key, GameObject entity)
    {
        this.key = key;
        this.gameObject = entity;
    }
}

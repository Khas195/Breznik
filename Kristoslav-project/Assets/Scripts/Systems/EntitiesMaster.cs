using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
public class EntitiesMaster : SingletonMonobehavior<EntitiesMaster>
{
    public enum EntitiesKey
    {
        PLAYER,
        PLAYERCAMERA
    }
    [SerializeField]
    [ReadOnly]
    List<EntityPack> globalEntities = new List<EntityPack>();
    protected override void Awake()
    {
        base.Awake();
        Debug.Log("Entity Master Wake");
    }
    public void RegisterEntity(EntitiesKey key, GameObject entity)
    {
        if (entity == null)
        {
            Logger.EntitiesMasterDebug(this, " try to register null as an entity with key: " + key);
            return;
        }

        var pack = TryToGetValue(key);
        if (pack != null)
        {
            pack.gameObject = entity;
        }
        else
        {
            globalEntities.Add(new EntityPack(key, entity));
        }
    }
    public void UnregisterEntity(EntitiesKey key, GameObject entity)
    {
        if (entity == null)
        {
            Logger.EntitiesMasterDebug(this, " try to unregister null as an entity with key: " + key);
            return;
        }
        EntityPack pack = TryToGetValue(key);
        if (pack != null)
        {
            globalEntities.Remove(pack);
            pack = null;
        }
        else
        {
            Logger.EntitiesMasterDebug(this, " try to unregister an unexisting pack as with key: " + key);
        }
    }

    private EntityPack TryToGetValue(EntitiesKey key)
    {
        return globalEntities.Find(pack => pack.key == key);
    }

    public GameObject GetGlobalEntity(EntitiesKey key)
    {
        var pack = TryToGetValue(key);
        if (pack != null)
        {
            return pack.gameObject;
        }
        else
        {
            return null;
        }
    }
    public void Clear()
    {
        globalEntities.Clear();
    }
}

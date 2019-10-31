using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory/Inventory")]
public class InventoryObject : ScriptableObject
{
    [SerializeField]
    List<ItemObject> container = new List<ItemObject>();

    public bool AddItem(ItemObject newItem)
    {
        if (container.Contains(newItem))
        {
            Logger.InventoryDebug("Trying to add the same instance of an item twice");
            return false;
        }

        container.Add(newItem);
        return true;
    }
    public bool RemoveItem(ItemObject targetItem)
    {
        if (container.Contains(targetItem) == false)
        {
            Logger.InventoryDebug("Trying to remove an item that does not exist in the inventory");
            return false;
        }
        container.Remove(targetItem);
        return true;
    }

    public void ClearContainer()
    {
        container.Clear();
    }

    public ItemObject LookUpItem(string itemName)
    {
        return container.Find(item => item.name == itemName);
    }
}

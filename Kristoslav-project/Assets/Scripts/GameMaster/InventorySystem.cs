using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : SingletonMonobehavior<InventorySystem>
{
    [SerializeField]
    InventoryObject inventory = null;

    [SerializeField]
    InventoryUIManager uIManager = null;

    [SerializeField]
    ItemObject test = null;
    [SerializeField]
    ItemObject test1 = null;



    [SerializeField]
    ItemObject test2 = null;
    protected override void Awake()
    {
        base.Awake();
        inventory.ClearContainer();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            this.AddItem(test);
            FocusItem(test);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            this.AddItem(test1);
            FocusItem(test1);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            this.AddItem(test2);
            FocusItem(test2);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            this.RemoveItem(test);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            this.RemoveItem(test1);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            this.RemoveItem(test2);
        }
    }
    public void AddItem(ItemObject newItem)
    {
        if (inventory.AddItem(newItem))
        {
            uIManager.AddItem(newItem);
        }
    }
    public void RemoveItem(ItemObject targetItem)
    {
        if (inventory.RemoveItem(targetItem))
        {
            uIManager.RemoveItem(targetItem);
        }
    }
    public void FocusItem(ItemObject targetItem)
    {
        uIManager.FocusItem(targetItem);
    }
    public ItemObject GetItem(string itemName)
    {
        return inventory.LookUpItem(itemName);
    }
    public void HideUI()
    {
        this.uIManager.gameObject.SetActive(false);
    }
    public void ShowUI()
    {
        this.uIManager.gameObject.SetActive(true);
    }
}

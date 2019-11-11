using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : IInteractable 
{
    [SerializeField]
    GameObject itemEntity = null;
    [SerializeField]
    ItemObject itemData = null;
    [SerializeField]
    Canvas itemCanvas = null;
    void Awake()
    {
    }
    public override void Defocus(GameObject interacter)
    {
        base.Defocus(interacter);
        itemCanvas.gameObject.SetActive(false);
    }

    public override void Focus(GameObject interacter)
    {
        base.Focus(interacter);
        itemCanvas.gameObject.SetActive(true);
    }

    public override string GetKindOfInteraction()
    {
        return "Pick up";
    }

    public override string GetName()
    {
        return itemData.name; 
    }

    public override bool Interact(GameObject interacter)
    {
        if (base.Interact(interacter) == false) return false;
        InventorySystem.GetInstance().AddItem(this.itemData);
        Destroy(this.itemEntity);
        return true;
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithItems : MonoBehaviour
{
    public void OnObjectExitSphere(Collider other)
    {
        var itemComponent = other.GetComponentInChildren<Item>();
        if (itemComponent)
        {
            InteractableMananger.GetInstance().OnInteractableExit(itemComponent);
        }
    }
    public void OnObjectEnterSphere(Collider other)
    {
        var itemComponent = other.GetComponentInChildren<Item>();
        if (itemComponent)
        {
            InteractableMananger.GetInstance().OnInteractableEnter(itemComponent);
        }
    }
}

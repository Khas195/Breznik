using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TalkToNPC : MonoBehaviour
{
    public void OnObjectExitSphere(Collider other)
    {
        var NPCinteract = other.GetComponentInChildren<NPCInteractable>();
        if (NPCinteract)
        {
            InteractableMananger.GetInstance().OnInteractableExit(NPCinteract);
        }
    }

    public void OnObjectEnterSphere(Collider other)
    {
        var NPCinteract = other.GetComponentInChildren<NPCInteractable>();
        if (NPCinteract)
        {
            InteractableMananger.GetInstance().OnInteractableEnter(NPCinteract);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TalkToNPC : MonoBehaviour
{
    NPCInteractable currentNPC = null;
    public void OnObjectExitSphere(Collider other)
    {
        var NPCinteract = other.GetComponentInChildren<NPCInteractable>();
        if (NPCinteract)
        {
            NPCinteract.Defocus(this.transform.parent.gameObject);
            Logger.NPCDebug(other.transform.parent + " leave interacting range");
            
            currentNPC = null;
        }
    }

    public void OnObjectEnterSphere(Collider other)
    {
        var NPCinteract = other.GetComponentInChildren<NPCInteractable>();
        if (NPCinteract)
        {
            NPCinteract.Focus(this.transform.parent.gameObject);
            Logger.NPCDebug(this.transform.parent + " found an NPC");
            currentNPC = NPCinteract;
        }
    }
    public void Talk() {
        if (currentNPC) {
            Logger.NPCDebug("Initiate conversation with " + currentNPC.GetName());
            currentNPC.Interact(this.transform.parent.gameObject);
        } else {
            Logger.NPCDebug("No one to talk to");
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}

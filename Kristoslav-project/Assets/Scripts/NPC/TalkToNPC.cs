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
            Definition.NPCDebug(other.transform.parent + " leave interacting range");
            currentNPC = null;
        }
    }

    public void OnObjectEnterSphere(Collider other)
    {
        var NPCinteract = other.GetComponentInChildren<NPCInteractable>();
        if (NPCinteract)
        {
            NPCinteract.Focus(this.transform.parent.gameObject);
            Definition.NPCDebug(this.transform.parent + " found an NPC");
            currentNPC = NPCinteract;
        }
    }
    public void Talk() {
        if (currentNPC) {
            Definition.NPCDebug("Initiate conversation with " + currentNPC.GetName());
            currentNPC.Interact(this.transform.parent.gameObject);
        } else {
            Definition.NPCDebug("No one to talk to");
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}

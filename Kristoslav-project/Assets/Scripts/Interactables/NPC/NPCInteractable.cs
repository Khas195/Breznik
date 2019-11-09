using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteractable : IInteractable
{
    [SerializeField]
    List<MonologueData> datas = null;
    [SerializeField]
    GameObject host = null;
    [SerializeField]
    float breakConversationDistance = 0;
    [SerializeField]
    string NPCName = "";
    [SerializeField]
    Text npcNameUi = null;
    [SerializeField]
    RotateToward towardCharRotator = null;
    GameObject otherSpeaker = null;
    bool isTracking;
    void Start()
    {
        npcNameUi.text = NPCName;
    }
    public override void Defocus(GameObject interacter)
    {
        base.Defocus(interacter);
        Logger.NPCDebug("Defocus " + this);
    }
    public override void Focus(GameObject interacter)
    {
        base.Focus(interacter);
        Logger.NPCDebug("Focus " + this);

    }

    public override GameObject GetGameObject()
    {
        return base.GetGameObject();
    }

    public override bool Interact(GameObject interacter)
    {
        Logger.NPCDebug("Talk to " + this);
        if (base.Interact(interacter))
        {
            if (GameMaster.GetInstance().RequestGameState(GameState.States.InDiagloues))
            {
                foreach (var data in datas)
                {
                    MonologueManager.GetInstance().QueueMonologue(data);
                }
                isTracking = true;
            }
            otherSpeaker = interacter;
        }
        return false;
    }
    void Update()
    {
        //RotateTowardCamera();
        if (isTracking)
        {
            this.towardCharRotator.enabled = true;
            if (Vector3.Distance(otherSpeaker.transform.position, host.transform.position) > breakConversationDistance)
            {
                isTracking = false;
                MonologueManager.GetInstance().HardReset();
                GameMaster.GetInstance().RequestGameState(GameState.States.InGame);
            }
            if (GameMaster.GetInstance().GetCurrentGameState().GetState() != GameState.States.InDiagloues)
            {
                this.towardCharRotator.enabled = false;
                isTracking = false;
            }

        }
    }

    public override string GetName()
    {
        return NPCName;
    }
    public override string GetKindOfInteraction()
    {
        return "Talk to";
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(host.transform.position, breakConversationDistance);
    }
}

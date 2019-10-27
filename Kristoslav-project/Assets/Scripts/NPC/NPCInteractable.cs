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
    CharacterData playerData = null;
    [SerializeField]
    float rotateSpeed = 0;
    [SerializeField]
    float breakConversationDistance = 0;
    [SerializeField]
    Text npcNameUI = null;
    [SerializeField]
    Canvas npcCanvas = null;
    bool isTracking;
    void Start()
    {
        npcNameUI.text = this.GetName();
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
        }
        return false;
    }
    void Update()
    {
        RotateTowardCamera();
        if (isTracking)
        {
            RotateTowardPlayer();
            if (Vector3.Distance(playerData.position, host.transform.position) > breakConversationDistance)
            {
                isTracking = false;
                MonologueManager.GetInstance().HardReset();
                GameMaster.GetInstance().RequestGameState(GameState.States.InGame);
            }
            if (GameMaster.GetInstance().GetCurrentGameState().GetState() != GameState.States.InDiagloues)
            {
                isTracking = false;
            }

        }
    }
    private void RotateTowardCamera()
    {
        var camPos = playerData.cameraPos;
        camPos.y = 0;
        var charPos = host.transform.position;
        charPos.y = 0;
        npcCanvas.transform.rotation = Quaternion.LookRotation((camPos - charPos).normalized);
    }
    private void RotateTowardPlayer()
    {
        var direction = (playerData.position - host.transform.position).normalized;
        var lookRotation = Quaternion.LookRotation(direction);
        host.transform.rotation = Quaternion.Slerp(host.transform.rotation, lookRotation, rotateSpeed * Time.deltaTime);
    }

    public override string GetName()
    {
        return "Tung";
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

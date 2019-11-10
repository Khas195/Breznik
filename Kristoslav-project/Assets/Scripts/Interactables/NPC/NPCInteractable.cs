using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteractable : IInteractable
{
    [SerializeField]
    [Required]
    [BoxGroup("Required")]
    GameObject host = null;
    [SerializeField]
    [BoxGroup("Required")]
    string NPCName = "";
    [SerializeField]
    [Required]
    [BoxGroup("Required")]
    Text npcNameUi = null;

    [SerializeField]
    List<MonologueData> datas = null;

    [SerializeField]
    float breakConversationDistance = 3;

    [SerializeField]
    private float rotateSpeed = 10f;
    GameObject otherSpeaker = null;
    bool isTracking = false;
    private GameObject playerObject = null;


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
                playerObject = EntitiesMaster.GetInstance().GetGlobalEntity(EntitiesMaster.EntitiesKey.PLAYER);
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
            RotateTowardPlayer();
            if (Vector3.Distance(otherSpeaker.transform.position, host.transform.position) > breakConversationDistance)
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

    private void RotateTowardPlayer()
    {
        var direction = playerObject.transform.position - host.transform.position;
        direction.y = 0;
        var lookRot = Quaternion.LookRotation(direction.normalized);
        host.transform.rotation = Quaternion.Slerp(host.transform.rotation, lookRot, rotateSpeed * Time.deltaTime);
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

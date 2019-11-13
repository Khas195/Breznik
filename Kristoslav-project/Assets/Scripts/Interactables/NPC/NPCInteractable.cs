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
    CharacterData charData = null;
    [SerializeField]
    [Required]
    [BoxGroup("Required")]
    Text npcNameUi = null;

    [SerializeField]
    List<MonologueData> beforeQuestIsFinished = new List<MonologueData>();
    [SerializeField]
    List<MonologueData> questFinishedTalk = new List<MonologueData>();
    [SerializeField]
    List<MonologueData> whileQuestIsActive = new List<MonologueData>();
    [SerializeField]
    List<MonologueData> afterQuestIsFinished = new List<MonologueData>();

    [SerializeField]
    [ReadOnly]
    Quest givenQuest = null;
    [SerializeField]
    float breakConversationDistance = 3;

    [SerializeField]
    private float rotateSpeed = 10f;
    GameObject otherSpeaker = null;
    bool isTracking = false;
    private GameObject playerObject = null;


    void Start()
    {
        npcNameUi.text = charData.characterName;
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
                if (givenQuest)
                {
                    if (QuestSystem.GetInstance().CheckIfActiveQuestIsCompleted(givenQuest))
                    {
                        Talk(questFinishedTalk);
                    }
                    else if (QuestSystem.GetInstance().CheckIfQuestArchived(givenQuest))
                    {
                        Talk(afterQuestIsFinished);
                    }
                    else if (QuestSystem.GetInstance().IsActiveQuest(givenQuest))
                    {
                        Talk(whileQuestIsActive);
                    }
                }
                else
                {
                    Talk(beforeQuestIsFinished);
                }
                isTracking = true;
                if (playerObject == null)
                {
                    playerObject = EntitiesMaster.GetInstance().GetGlobalEntity(EntitiesMaster.EntitiesKey.PLAYER);
                }
            }
            otherSpeaker = interacter;
        }
        return false;
    }

    private void Talk(List<MonologueData> monologues)
    {
        foreach (var data in monologues)
        {
            MonologueManager.GetInstance().QueueMonologue(data);
            if (data.quest)
            {
                givenQuest = data.quest;
            }
        }
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
        return charData.characterName;
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

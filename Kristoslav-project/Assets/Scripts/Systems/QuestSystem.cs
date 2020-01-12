using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class OnQuestEvent : UnityEvent<Quest>
{
}
public class QuestSystem : SingletonMonobehavior<QuestSystem>
{
    [SerializeField]
    List<Quest> activeQuest = new List<Quest>();
    public OnQuestEvent questCompletedEvent = new OnQuestEvent();
    public OnQuestEvent questAddedEvent = new OnQuestEvent();

    List<Quest> completedQuest = new List<Quest>();
    [SerializeField]
    Quest test = null;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            this.AddQuest(test);
        }
    }
    public bool CheckIfActiveQuestIsCompleted(Quest quest)
    {
        if (activeQuest.Contains(quest))
        {
            if (quest.IsCompleted())
            {
                questCompletedEvent.Invoke(quest);
                completedQuest.Add(quest);
                RemoveQuest(quest);
                return true;
            }
            return false;
        }
        return false;
    }
    public bool CheckIfQuestArchived(Quest quest)
    {
        return completedQuest.Contains(quest);
    }

    public bool AddQuest(Quest newQuest)
    {
        if (activeQuest.Contains(newQuest))
        {
            Debug.Log("Trying to receive the same quest");
            return false;
        }
        newQuest.Reset();
        activeQuest.Add(newQuest);
        newQuest.Activate();
        questAddedEvent.Invoke(newQuest);
        return true;
    }
    public bool RemoveQuest(Quest targetQuest)
    {
        if (activeQuest.Contains(targetQuest) == false)
        {
            Debug.Log("Trying to remove non-active quest.");
            return false;
        }
        activeQuest.Remove(targetQuest);
        targetQuest.Deactivate();
        return true;
    }
    public List<Quest> GetActiveQuests()
    {
        return activeQuest;
    }

    public bool IsActiveQuest(Quest givenQuest)
    {
        return activeQuest.Contains(givenQuest);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    Quest test;
    void Update()
    {
        UpdateQuests();
        if (Input.GetKeyDown(KeyCode.O)) {
            this.AddQuest(test);
        }
    }

    private void UpdateQuests()
    {
        for (int i = 0; i < activeQuest.Count; i++)
        {
            if (activeQuest[i].IsCompleted())
            {
                questCompletedEvent.Invoke(activeQuest[i]);
                completedQuest.Add(activeQuest[i]);
                RemoveQuest(activeQuest[i]);
            }
        }
    }

    public bool AddQuest(Quest newQuest)
    {
        if (activeQuest.Contains(newQuest))
        {
            Debug.Log("Trying to receive the same quest");
            return false;
        }

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
}

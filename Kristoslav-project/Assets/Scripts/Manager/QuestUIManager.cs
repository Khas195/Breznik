using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUIManager : MonoBehaviour
{
    [SerializeField]
    Text questLog;
    // Update is called once per frame
    void Update()
    {

    }
    public void OnQuestAdded(Quest addedQuest)
    {
        UpdateQuestLod();
    }

    private void UpdateQuestLod()
    {
        var activeQuests = QuestSystem.GetInstance().GetActiveQuests();
        questLog.text = "";
        for (int i = 0; i < activeQuests.Count; i++)
        {
            questLog.text += activeQuests[i].description + "\n";
            for (int j = 0; j < activeQuests[i].objectives.Count; j++)
            {
                questLog.text += activeQuests[i].objectives[j].description + " " + activeQuests[i].objectives[j].achieved + "/"
                + activeQuests[i].objectives[j].amount + "\n";
            }
        }
    }
}

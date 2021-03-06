using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MonologueManager : MonoBehaviour
{
    [SerializeField]
    GameObject monologueUI;
    [SerializeField]
    Text monologueText;

    MonologueData curData;
    [SerializeField]
    Queue<MonologueData> monologueList = new Queue<MonologueData>();

    float curSentenceTime;
    int curSentenceIndex = 0;
    bool isPlaying;

    static MonologueManager instance;
    public static MonologueManager GetInstance()
    {
        return instance;
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void Skip()
    {
        if (IsMonologueFinished())
        {
            if (DoesContainQuestInMonologue())
            {
                QuestSystem.GetInstance().AddQuest(curData.quest);
            }
            Reset();

            if (IsMonologueInQueue())
            {
                PlayNext();
            }
        }
        else
        {
            NextSentence();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            monologueText.text = curData.GetSentence(curSentenceIndex);
            curSentenceTime -= Time.deltaTime;
            if (IsCurrentSentenceFinished())
            {
                if (IsMonologueFinished())
                {
                    if (DoesContainQuestInMonologue())
                    {
                        QuestSystem.GetInstance().AddQuest(curData.quest);
                    }
                    Reset();

                    if (IsMonologueInQueue())
                    {
                        PlayNext();
                    }
                }
                else
                {
                    NextSentence();
                }
            }
        }
        else
        {
            monologueUI.SetActive(false);
        }
    }

    private bool DoesContainQuestInMonologue()
    {
        return curData.quest != null;
    }

    public void SetTextUI(Text textUI)
    {
        this.monologueText = textUI;
    }

    public void SetMonologueUI(GameObject ui)
    {
        this.monologueUI = ui;
    }

    private void PlayNext()
    {
        Play(monologueList.Dequeue());
    }

    private bool IsMonologueInQueue()
    {
        return monologueList.Count > 0;
    }

    private bool IsCurrentSentenceFinished()
    {
        return curSentenceTime <= 0;
    }

    private void NextSentence()
    {
        curSentenceIndex++;
        curSentenceTime = curData.timeBetweenEachSentence;
    }

    private bool IsMonologueFinished()
    {
        return curSentenceIndex + 1 >= curData.GetNumberOfSentences();
    }

    private void Reset()
    {
        isPlaying = false;
        curData = null;
        curSentenceIndex = 0;
        curSentenceTime = 0;
        monologueText.text = "";
        monologueUI.SetActive(false);
    }
    public void HardReset()
    {
        Reset();
        monologueList.Clear();
    }
    public void QueueMonologue(MonologueData newMonologue)
    {
        monologueList.Enqueue(newMonologue);
        if (!isPlaying)
        {
            Reset();
            PlayNext();
        }
    }
    public void Play(MonologueData monologue)
    {
        isPlaying = true;
        curSentenceTime = monologue.timeBetweenEachSentence;
        curData = monologue;
        monologueUI.SetActive(true);
    }
    public void Play(string sentence)
    {
        var monologue = new MonologueData();
        monologue.sentences = new List<string>();
        monologue.sentences.Add(sentence);
        monologue.timeBetweenEachSentence = 2;
        isPlaying = true;
        curSentenceTime = monologue.timeBetweenEachSentence;
        curData = monologue;
        monologueUI.SetActive(true);
    }
    public bool IsPlaying()
    {
        return isPlaying;
    }
}

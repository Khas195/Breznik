using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/State")]
public class ScriptableState : ScriptableObject
{
    [SerializeField]
    Color gizmosColor = Color.gray;
    [SerializeField]
    List<Action> actions = new List<Action>();
    [SerializeField]
    List<Transition> transitions = new List<Transition>();
    public void UpdateState(NPCController controller)
    {
        DoAction(controller);
        CheckTransitions(controller);
    }
    void DoAction(NPCController controller)
    {
        for (int i = 0; i < actions.Count; i++)
        {
            actions[i].Act(controller);
        }
    }
    void CheckTransitions(NPCController controller)
    {
        for (int i = 0; i < transitions.Count; i++)
        {
            bool decisionSucceeded = transitions[i].decision.Decide(controller);
            if (decisionSucceeded)
            {
                controller.RequestTransition(transitions[i].trueState);
            }
            else
            {
                controller.RequestTransition(transitions[i].falseState);
            }
        }
    }
    public Color GetGizmosColor()
    {
        return gizmosColor;
    }
}


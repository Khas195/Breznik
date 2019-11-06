using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationComboEvent : MonoBehaviour
{
    [SerializeField]
    GameEvent OnAttackBegin = null;
    [SerializeField]
    GameEvent OnAttackEnd = null;
    public void BeginCombo() {
        OnAttackBegin.Raise();
    }

    public void EndCombo() {
        Debug.Log("Combo end");
        OnAttackEnd.Raise();
    }
}

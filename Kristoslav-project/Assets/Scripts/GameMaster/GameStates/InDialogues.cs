using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InDialogues :GameState 
{
    [SerializeField]
    GameObject dialogueUI;
    MonologueManager manager;
    public override void OnPopped()
    {
        base.OnPopped();
        dialogueUI.SetActive(false);
        this.gameObject.SetActive(false);
    }
    public override void OnPushed()
    {
        base.OnPushed();
        dialogueUI.SetActive(true);
        this.gameObject.SetActive(true);
        manager = MonologueManager.GetInstance();
    }
    void Update()
    {
        if (manager.IsPlaying() == false) {
            GameMaster.GetInstance().RequestGameState(GameState.States.InGame);
        } 
        if (Input.GetKeyDown(KeyCode.E)) {
            manager.Skip();
        }
    }
}

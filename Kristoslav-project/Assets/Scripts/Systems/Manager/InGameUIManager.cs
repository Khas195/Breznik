using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUIManager : SingletonMonobehavior<InGameUIManager>
{
    [SerializeField]
    GameObject inGameOverlay;
    [SerializeField]
    GameObject pausedMenu;

    public void TurnOnOverlay()
    {
        inGameOverlay.SetActive(true);
    }
    public void TurnOffOverlay()
    {
        inGameOverlay.SetActive(false);
    }
    public void TurnOnPausedMenu()
    {
        pausedMenu.SetActive(true);
    }
    public void TurnOffPausedMenu()
    {
        pausedMenu.SetActive(false);
    }
}

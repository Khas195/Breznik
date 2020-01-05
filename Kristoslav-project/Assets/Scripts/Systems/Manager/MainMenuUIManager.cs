using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUIManager : SingletonMonobehavior<MainMenuUIManager>
{
    [SerializeField]
    GameObject mainMenuPanel;

    public void Show()
    {
        mainMenuPanel.SetActive(true);
    }
    public void Hide()
    {
        mainMenuPanel.SetActive(false);
    }

}

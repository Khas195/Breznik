using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUIManager : SingletonMonobehavior<MainMenuUIManager>
{
    [SerializeField]
    Animator mainMenuPanel;

    public void Show()
    {
        mainMenuPanel.SetTrigger("In");
    }
    public void Hide()
    {
        mainMenuPanel.SetTrigger("Out");
    }

}

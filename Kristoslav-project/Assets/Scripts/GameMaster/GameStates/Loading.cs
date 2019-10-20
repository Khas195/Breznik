using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : GameState
{
    [SerializeField]
    Slider slider;
    [SerializeField]
    Text loadingText;
    
    public override void OnPopped()
    {
        base.OnPopped();
        this.gameObject.SetActive(false);
        GameMaster.GetInstance().SetMouseVisibility(true);
    }
    public override void OnPushed()
    {
        base.OnPushed();
        this.gameObject.SetActive(true);
        GameMaster.GetInstance().SetMouseVisibility(false);
        GameMaster.GetInstance().LoadScene(slider, loadingText);
    }
}

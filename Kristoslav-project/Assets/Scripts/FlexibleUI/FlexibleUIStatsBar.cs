using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlexibleUIStatsBar : FlexibleUI
{
    public enum StatsBarType
    {
        HealthBar,
        StaminaBar
    }
    [SerializeField]
    StatsBarType type;

    Image border;
    Image background;
    Image filled;

    protected override void OnSkinUI()
    {
        base.OnSkinUI();
        AddMissingComponent();

        switch (type)
        {
            case StatsBarType.HealthBar:
                border.sprite = uIData.healthBar.borderSprite;
                background.sprite = uIData.healthBar.backgroundSprite;
                filled.sprite = uIData.healthBar.filledSprite;
                break;
            case StatsBarType.StaminaBar:
                border.sprite = uIData.staminaBar.borderSprite;
                background.sprite = uIData.staminaBar.backgroundSprite;
                filled.sprite = uIData.staminaBar.filledSprite;
                break;
            default:
                border.sprite = uIData.healthBar.borderSprite;
                background.sprite = uIData.healthBar.backgroundSprite;
                filled.sprite = uIData.healthBar.filledSprite;
                break;


        }
        border.type = Image.Type.Sliced;
        background.type = Image.Type.Sliced;

        filled.type = Image.Type.Filled;
        filled.fillMethod = Image.FillMethod.Horizontal;
    }

    public void SetFilledAmount(float value)
    {
        filled.fillAmount = value;
    }

    public float GetFilledAmount()
    {
        return filled.fillAmount;
    }

    private void AddMissingComponent()
    {
        if (background == null)
        {
            var backgroundGameObject = this.transform.Find("Background");
            if (backgroundGameObject == null)
            {
                this.background = CreateChildImage("Background");
            }
            else
            {
                this.background = backgroundGameObject.GetComponent<Image>();
            }
        }
        if (filled == null)
        {
            var filledGameObject = this.transform.Find("Filled");
            if (filledGameObject == null)
            {
                this.filled= CreateChildImage("Filled");
            }
            else
            {
                this.filled= filledGameObject.GetComponent<Image>();
            }
        }
        if (border == null)
        {
            var borderGameObject = this.transform.Find("Border");
            if (borderGameObject == null)
            {
                this.border= CreateChildImage("Border");
            }
            else
            {
                this.border= borderGameObject.GetComponent<Image>();
            }
        }

    }

    private Image CreateChildImage(string name)
    {
        Image result = null;
        var targetObject = new GameObject();
        targetObject.transform.parent = this.transform;
        AddStretchRectTransform(targetObject);
        targetObject.name = name;
        result = targetObject.AddComponent<Image>();
        return result;
    }

    private void AddStretchRectTransform(GameObject targetGameObject)
    {
        var bgRect = targetGameObject.AddComponent<RectTransform>();
        bgRect.anchoredPosition = Vector2.zero;
        bgRect.anchorMax = new Vector2(1, 1);
        bgRect.anchorMin = new Vector2(0, 0);
        bgRect.pivot = new Vector2(.5f, .5f);
        bgRect.offsetMax = new Vector2(0, 0);
        bgRect.offsetMin = new Vector2(0, 0);
        bgRect.localScale = new Vector3(1, 1, 1);
    }



}

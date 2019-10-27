using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlexibleUIDotsBar : FlexibleUI
{
    [SerializeField]
    List<Image> usedDot = new List<Image>();
    [SerializeField]
    List<Image> unusedDot = new List<Image>();

    [SerializeField]
    RectTransform rectTransform = null;
    int curCount;
    public override void Awake()
    {
        base.Awake();
        curCount = uIData.staminaDots.maxCount;
    }

    public override void Update()
    {
        base.Update();
    }

    protected override void OnSkinUI()
    {
        base.OnSkinUI();
        if (uIData.staminaDots)
        {
            AddMissingComponent();
            ArrangeIcons();
        }
    }
    public void SetCount(int count)
    {
        if (count > uIData.staminaDots.maxCount) {
            count = uIData.staminaDots.maxCount;
            return;
        }
        curCount = count;
        for (int i = 0; i < unusedDot.Count; i++)
        {
            if (i <= count)
            {
                unusedDot[i].gameObject.SetActive(true);
            }
            else
            {
                unusedDot[i].gameObject.SetActive(false);
            }
        }
    }

    public int GetCount()
    {
        return curCount;
    }

    public void ArrangeIcons()
    {
        for (int i = 0; i < usedDot.Count; i++)
        {
            Arrange(i, uIData.staminaDots.UnusedSprite, unusedDot[i]);
            Arrange(i, uIData.staminaDots.UsedSprite, usedDot[i]);
        }
    }

    private void Arrange(int i, Sprite sprite, Image image)
    {
        image.sprite = sprite;

        var rectTrans = image.GetComponent<RectTransform>();
        rectTrans.anchoredPosition = Vector3.zero;
        rectTrans.sizeDelta = new Vector2(uIData.staminaDots.IconWidth, uIData.staminaDots.iconHeight);

        var posX = rectTransform.localPosition.x +
        (uIData.staminaDots.IconWidth + uIData.staminaDots.spaceBetween) * i + uIData.staminaDots.IconWidth;

        rectTrans.localPosition = new Vector3(posX, 0, 0);

        rectTrans.localScale = Vector3.one;
    }

    protected void AddMissingComponent()
    {
        if (uIData.staminaDots.maxCount != usedDot.Count)
        {
            usedDot.Clear();
            unusedDot.Clear();
        }
        for (int i = 0; i < uIData.staminaDots.maxCount; i++)
        {
            var usedImage = CreateIcon("Used" + i, uIData.staminaDots.UsedSprite, i);
            if (usedImage)
            {
                if (usedDot.Contains(usedImage) == false)
                {
                    usedDot.Add(usedImage);
                }
            }
            var unusedImage = CreateIcon("unUsed" + i, uIData.staminaDots.UnusedSprite, i);
            if (unusedImage)
            {
                if (unusedDot.Contains(unusedImage) == false)
                {
                    unusedDot.Add(unusedImage);
                }
            }
        }
    }

    private Image CreateIcon(string name, Sprite sprite, int index)
    {
        Image result = null;
        Transform iconGO = this.transform.Find(name);
        if (iconGO == null)
        {
            var usedGO = new GameObject(name);
            usedGO.transform.parent = this.transform;
            result = usedGO.AddComponent<Image>();
        }
        else
        {
            result = iconGO.GetComponent<Image>();
        }
        return result;
    }
    public void SetFilledAmount(float value)
    {
        var count = value * uIData.staminaDots.maxCount;
        curCount = Mathf.FloorToInt(count);
        FillMissing(curCount);
    }

    private void FillMissing(float count)
    {
        for (int i = 0; i < unusedDot.Count; i++)
        {
            if (i < count) {
                unusedDot[i].gameObject.SetActive(true);
            } else {
                unusedDot[i].gameObject.SetActive(false);
            }
        }
    }

    public float GetFilledAmount()
    {
        return curCount/uIData.staminaDots.maxCount;
    }
}

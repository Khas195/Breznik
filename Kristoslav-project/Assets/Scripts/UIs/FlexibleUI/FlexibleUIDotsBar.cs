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
        curCount = uIData.healthDots.maxCount;
    }

    public override void Update()
    {
        base.Update();
    }

    protected override void OnSkinUI()
    {
        base.OnSkinUI();
        if (uIData.healthDots)
        {
            AddMissingComponent();
            ArrangeIcons();
        }
    }
    public void SetCount(int count)
    {
        if (count > uIData.healthDots.maxCount)
        {
            count = uIData.healthDots.maxCount;
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
            Arrange(i, uIData.healthDots.UsedSprite[i], usedDot[i],
            this.uIData.healthDots.usedSpriteIconWidth,
            this.uIData.healthDots.usedSpriteIconHeight,
            uIData.healthDots.onTopUsedSprite);
        }
        for (int i = 0; i < unusedDot.Count; i++)
        {
            Arrange(i, uIData.healthDots.UnusedSprite[i], unusedDot[i],
            this.uIData.healthDots.unUsedSpriteIconWidth,
            this.uIData.healthDots.unusedSpriteIconHeight,
            uIData.healthDots.onTopUnusedSprite);
        }
    }

    private void Arrange(int i, Sprite sprite, Image image, float width, float height, bool onTop)
    {
        image.sprite = sprite;

        var rectTrans = image.GetComponent<RectTransform>();
        rectTrans.anchoredPosition = Vector3.zero;
        rectTrans.sizeDelta = new Vector2(width, height);
        float posX = 0;
        if (onTop)
        {
            posX = rectTransform.localPosition.x + width / 2;
        }
        else
        {
            posX = rectTransform.localPosition.x +
                    (width + uIData.healthDots.spaceBetween) * i + width / 2;
        }
        rectTrans.localPosition = new Vector3(posX, 0, 0);

        rectTrans.localScale = Vector3.one;
    }

    protected void AddMissingComponent()
    {
        if (uIData.healthDots.maxCount != unusedDot.Count)
        {
            usedDot.Clear();
            unusedDot.Clear();
        }
        for (int i = 0; i < uIData.healthDots.maxCount; i++)
        {
            if (i < uIData.healthDots.UsedSprite.Count)
            {
                var usedImage = CreateIcon("Used" + i, uIData.healthDots.UsedSprite[i], i);
                if (usedImage)
                {
                    if (usedDot.Contains(usedImage) == false)
                    {
                        usedDot.Add(usedImage);
                    }
                }
            }
            if (i < uIData.healthDots.UnusedSprite.Count)
            {
                var unusedImage = CreateIcon("unUsed" + i, uIData.healthDots.UnusedSprite[i], i);
                if (unusedImage)
                {
                    if (unusedDot.Contains(unusedImage) == false)
                    {
                        unusedDot.Add(unusedImage);
                    }
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
        var count = value * uIData.healthDots.maxCount;
        curCount = Mathf.FloorToInt(count);
        FillMissing(curCount);
    }

    private void FillMissing(float count)
    {
        for (int i = 0; i < unusedDot.Count; i++)
        {
            if (i < count)
            {
                unusedDot[i].gameObject.SetActive(true);
            }
            else
            {
                unusedDot[i].gameObject.SetActive(false);
            }
        }
    }

    public float GetFilledAmount()
    {
        return curCount / uIData.healthDots.maxCount;
    }
}

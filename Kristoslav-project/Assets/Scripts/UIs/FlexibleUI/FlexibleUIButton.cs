using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Button))]
public class FlexibleUIButton : FlexibleUI
{
    Image image;
    Button button;
    public override void Awake()
    {
        base.Awake();
    }
    protected override void OnSkinUI()
    {
        base.OnSkinUI();
        image = this.GetComponent<Image>();
        button = this.GetComponent<Button>();

        button.transition = Selectable.Transition.SpriteSwap;
        button.targetGraphic = image;

        image.sprite =  uIData.ItemBackgroundSprite;
        image.type = Image.Type.Sliced;
        button.spriteState = uIData.itemButtonSpriteState;

    }
}

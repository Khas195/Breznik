using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Flexible UI Data")]
public class FlexibleUIData : ScriptableObject
{
    public StatsBarUIData healthBar;
    public DotsUIData healthDots;

    [Header("Inventory Item Background")]
    [ShowAssetPreview]
    public SpriteState itemButtonSpriteState;

    [ShowAssetPreview]
    public Sprite ItemBackgroundSprite;
}

using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Flexible UI Data")]
public class FlexibleUIData : ScriptableObject
{
    public StatsBarUIData healthBar;
    public DotsUIData staminaDots;

    [Header("Inventory Item Background")]
    public SpriteState itemButtonSpriteState;

    public Sprite ItemBackgroundSprite { get; internal set; }
}

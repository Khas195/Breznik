using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(menuName = "Flexible UI Data/StatsDotData")]
public class DotsUIData : ScriptableObject
{
    public int maxCount;

    public bool onTopUsedSprite = false;
    public List<Sprite> UsedSprite = new List<Sprite>();
    public bool onTopUnusedSprite = false;
    public List<Sprite> UnusedSprite = new List<Sprite>();
    public float usedSpriteIconHeight;
    public float unusedSpriteIconHeight;
    public float usedSpriteIconWidth;
    public float unUsedSpriteIconWidth;
    public float spaceBetween;
}

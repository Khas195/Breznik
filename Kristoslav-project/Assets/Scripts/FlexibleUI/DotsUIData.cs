using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(menuName = "Flexible UI Data/StatsDotData")]
public class DotsUIData : ScriptableObject
{
    public int maxCount;

    [ShowAssetPreview]
    public Sprite UsedSprite ;
    [ShowAssetPreview]
    public Sprite UnusedSprite ;
    public float iconHeight;

    public float IconWidth ;
    public float spaceBetween;
}

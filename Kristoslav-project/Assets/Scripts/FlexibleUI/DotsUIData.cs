using UnityEngine;

[CreateAssetMenu(menuName = "Flexible UI Data/StatsDotData")]
public class DotsUIData : ScriptableObject
{
    public int maxCount;

    public Sprite UsedSprite ;
    public Sprite UnusedSprite ;
    public float iconHeight;

    public float IconWidth ;
    public float spaceBetween;
}

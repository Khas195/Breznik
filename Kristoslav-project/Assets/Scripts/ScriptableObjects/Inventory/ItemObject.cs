using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DefaultItem", menuName = "Inventory/DefaultItem")]
public class ItemObject : ScriptableObject 
{
    public GameObject prefab;
    public Sprite portrait;

    [TextArea(15,20)]
    public string description;
}

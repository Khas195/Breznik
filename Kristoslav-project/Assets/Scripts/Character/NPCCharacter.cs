using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCCharacter : Character
{
    [SerializeField]
    Text nameTag = null;
    void OnValidate()
    {
        nameTag.text = this.characterData.name;
    }
}

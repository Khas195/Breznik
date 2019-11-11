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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

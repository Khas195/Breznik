using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatsUI : MonoBehaviour
{
    [SerializeField]
    EnemyCharacter character;
    [SerializeField]
    FlexibleUIStatsBar healthBar;
    [SerializeField]
    Canvas canvas;
    [SerializeField]
    CharacterData playerData;

    // Update is called once per frame
    void Update()
    {
        var statsData = character.GetCharacterStats();
        var targetHealthValue = statsData.curHealth / statsData.health;

        var curHealthValue = healthBar.GetFilledAmount();

        curHealthValue = Mathf.Lerp(curHealthValue, targetHealthValue, 0.1f);
        healthBar.SetFilledAmount(curHealthValue);
        canvas.transform.rotation = Quaternion.LookRotation((playerData.position - character.transform.position).normalized);

    }
}

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
        UpdateHealthbar();
        RotateTowardCamera();
    }

    private void UpdateHealthbar()
    {
        var statsData = character.GetCharacterStats();
        var targetHealthValue = statsData.curHealth / statsData.health;

        var curHealthValue = healthBar.GetFilledAmount();

        curHealthValue = Mathf.Lerp(curHealthValue, targetHealthValue, 0.1f);
        healthBar.SetFilledAmount(curHealthValue);
    }

    private void RotateTowardCamera()
    {
        var camPos = playerData.cameraPos;
        camPos.y = 0;
        var charPos = character.transform.position;
        charPos.y = 0;
        canvas.transform.rotation = Quaternion.LookRotation((camPos - charPos).normalized);
    }
}

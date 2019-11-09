using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatsUI : MonoBehaviour
{
    [SerializeField]
    Character character = null;
    [SerializeField]
    CharacterStatsData baseStats = null;
    [SerializeField]
    FlexibleUIStatsBar healthBar = null;
    [SerializeField]
    Canvas canvas = null;
    [SerializeField]
    CharacterData playerData = null;

    // Update is called once per frame
    void Update()
    {
        UpdateHealthbar();
        RotateTowardCamera();
    }

    private void UpdateHealthbar()
    {
        var targetHealthValue = character.GetHealth()/ baseStats.health;

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

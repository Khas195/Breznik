using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class NPCStatsUI : MonoBehaviour
{
    [SerializeField]
    [Required]
    Character character = null;
    [SerializeField]
    [Required]
    Canvas canvas = null;


    [SerializeField]
    bool hasHealthBar = true;
    [SerializeField]
    [ShowIf("hasHealthBar")]
    FlexibleUIStatsBar healthBar = null;
    [SerializeField]
    [ShowIf("hasHealthBar")]
    CharacterStatsData baseStats = null;
    GameObject cameraObject = null;

    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (hasHealthBar)
        {
            UpdateHealthbar();
        }
        RotateTowardCamera();
    }

    private void UpdateHealthbar()
    {
        var targetHealthValue = character.GetHealth() / baseStats.health;

        var curHealthValue = healthBar.GetFilledAmount();

        curHealthValue = Mathf.Lerp(curHealthValue, targetHealthValue, 0.1f);
        healthBar.SetFilledAmount(curHealthValue);
    }

    private void RotateTowardCamera()
    {
        if (cameraObject == null)
        {
            cameraObject = EntitiesMaster.GetInstance().GetGlobalEntity(EntitiesMaster.EntitiesKey.PLAYERCAMERA);
        }
        var camPos = cameraObject.transform.position;
        camPos.y = 0;
        var charPos = character.transform.position;
        charPos.y = 0;
        canvas.transform.rotation = Quaternion.LookRotation((camPos - charPos).normalized);
    }
}

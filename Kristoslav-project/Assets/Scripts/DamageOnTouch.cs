﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTouch : MonoBehaviour
{
   [SerializeField] 
   float damage = 1;
    void OnCollisionEnter(Collision collisionInfo)
    {
        var character = collisionInfo.gameObject.GetComponentInChildren<Character>();
        character.BeingDamage(damage);
    }
}

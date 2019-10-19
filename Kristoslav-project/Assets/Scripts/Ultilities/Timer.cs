using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    float time;

    float counter;
    bool counterTriggered = false;
    OnTimerDone callback = null;
    private float attackCooldown;

    public delegate void OnTimerDone();

    public Timer(float time, OnTimerDone callback)
    {
        this.time = time;
        this.callback = callback;
        this.Reset();
    }

    public Timer(float attackCooldown)
    {
        this.attackCooldown = attackCooldown;
        callback = null;
    }
    public bool IsDone()
    {
        return counter <= 0;
    }

    public void Tick()
    {
        if (counterTriggered == true)
        {
            counter -= Time.deltaTime;
            if (counter <= 0)
            {
                counterTriggered = false;
                if (callback != null)
                {
                    callback();
                }
            }
        }
    }
    public void SetTime(float time)
    {
        this.time = time;
    }
    public void SetCallback(OnTimerDone callback)
    {
        this.callback = callback;
    }
    public void Trigger()
    {
        counterTriggered = true;
    }
    public void Reset()
    {
        counter = time;
        counterTriggered = false;
    }

}

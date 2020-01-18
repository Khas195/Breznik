using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class LevitateEffect : MonoBehaviour
{
    [SerializeField]
    private float amplitude;

    private float amplitudeFactor;

    [SerializeField]
    private float speed;

    private float speedFactor;
    private float faze;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        this.timer = 0f;
        this.amplitudeFactor = Random.Range(0.5f, 1.5f);
        this.speedFactor = Random.Range(0.5f, 1.5f);
        this.faze = Random.Range(0f, 1f) * 180f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        this.transform.GetChild(0).localPosition = amplitude * amplitudeFactor * Mathf.Sin(speed * speedFactor * timer + faze) * Vector3.up;
    }
}

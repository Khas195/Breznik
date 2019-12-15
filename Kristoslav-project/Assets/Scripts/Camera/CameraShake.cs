using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField]
    Transform camTransform = null;

    [SerializeField]
    float shakeAmount = 0.7f;
    [SerializeField]
    float decreaseFactor = 1.0f;

    Vector3 originalPos;
    float shakeDuration = 0f;

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }
    }
    public void Shake(float duration)
    {
        this.shakeDuration = duration;
    }
}

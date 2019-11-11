using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOverTime : MonoBehaviour
{
    [SerializeField]
    GameObject hostObject = null;
    [SerializeField]
    float speed = 15f;
    [SerializeField]
    bool rotateX = false;
    [SerializeField]
    bool rotateY = true;
    [SerializeField]
    bool rotateZ = false;

    // Update is called once per frame
    void Update()
    {
        int x = rotateX ? 1 : 0;
        int y = rotateY ? 1 : 0;
        int z = rotateZ ? 1 : 0;
        var hostTransform = hostObject.transform;
        hostTransform.Rotate(speed * x * Time.unscaledDeltaTime, speed * y * Time.unscaledDeltaTime, speed * z * Time.unscaledDeltaTime);
    }
}

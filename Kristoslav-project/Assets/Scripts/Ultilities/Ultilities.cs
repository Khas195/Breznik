using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ultilities
{
    // Outdated, use Mathf.Lerp instead 
    public static float CalculateAsymptoticAverage(float currentValue, float target, float percentage)
    {
        var result = 0.0f;
        result = (1 - percentage) * currentValue + percentage * target;
        return result;
    }
    public static Vector3 CalculateMoveDirection(float horizontalInput, float forwardInput, Vector3 forwardDirection, Vector3 sideDirection)
    {
        Vector3 movedir;
        var forwardDir = forwardDirection * forwardInput;
        var sideDir = sideDirection * horizontalInput;
        movedir = forwardDir + sideDir;
        return movedir;
    }

}

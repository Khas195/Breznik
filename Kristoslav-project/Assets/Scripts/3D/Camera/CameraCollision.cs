using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    [SerializeField]
    Transform host = null;
    [SerializeField]
    Transform cameraTrans = null;
    [SerializeField]
    float minsDistance = 1f;
    [SerializeField]
    float maxDistance = 4f;
    [SerializeField]
    float smoothValue = 0.1f;

    Vector3 dollyDir;
    [SerializeField]
    [ReadOnly]
    Vector3 dollyDirAdjusted;
    [SerializeField]
    [ReadOnly]
    float currentDistance;
    [SerializeField]
    LayerMask checkMask;
    void Start()
    {
        dollyDir = cameraTrans.localPosition.normalized;
        currentDistance = cameraTrans.localEulerAngles.magnitude;
    }
    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(host.transform.position, host.TransformPoint(dollyDir * currentDistance));
    }
    void Update()
    {
        var desiredPos = host.TransformPoint(dollyDir * currentDistance);
        RaycastHit hit;

        if (Physics.Linecast(host.transform.position, desiredPos, out hit, checkMask))
        {
            currentDistance = Mathf.Clamp(hit.distance, minsDistance, maxDistance);
        }
        else
        {
            currentDistance = maxDistance;
        }
        cameraTrans.localPosition = Vector3.Lerp(cameraTrans.localPosition, dollyDir * currentDistance, Time.deltaTime * smoothValue);
    }
}

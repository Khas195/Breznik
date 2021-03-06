using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform host = null;

    [SerializeField]
    List<Transform> encapsolatedTarget = new List<Transform>();
    [SerializeField]
    Transform character = null;
    [SerializeField]
    [Tooltip("Each frame the camera move x percentage closer to the target")]
    float followPercentage = 0.02f;
    [SerializeField]
    bool followX = false;
    [SerializeField]
    bool followY = false;
    [SerializeField]
    bool followZ = false;
    [SerializeField]
    float maxDistance = 2;

    Camera mCamera;
    // Start is called before the first frame update
    void Start()
    {
        if (character != null)
        {
            encapsolatedTarget.Add(character);
        }
        mCamera = host.GetComponentInChildren<Camera>();
    }

    private void Update()
    {

    }
    void FixedUpdate()
    {
        var targetPos = GetCenterPosition(encapsolatedTarget);
        var hostPos = host.position;
        hostPos = LerpToward(targetPos, hostPos);

        host.position = hostPos;
    }
    void LateUpdate()
    {
        var targetPos = GetCenterPosition(encapsolatedTarget);
        var hostPos = host.position;
        if (Vector3.Distance(targetPos, hostPos) > maxDistance)
        {
            hostPos = targetPos - (targetPos - hostPos).normalized * maxDistance;
        }
        host.position = hostPos;
    }

    private Vector3 LerpToward(Vector3 targetPos, Vector3 curPos)
    {
        if (followX)
        {
            curPos.x = Mathf.Lerp(curPos.x, targetPos.x, followPercentage);
        }
        if (followY)
        {
            curPos.y = Mathf.Lerp(curPos.y, targetPos.y, followPercentage);
        }
        if (followZ)
        {
            curPos.z = Mathf.Lerp(curPos.z, targetPos.z, followPercentage);
        }
        return curPos;
    }

    public void SetFollowPercentage(float value)
    {
        followPercentage = value;
    }

    public void Clear(bool clearPlayer)
    {
        encapsolatedTarget.Clear();
        if (clearPlayer == false)
        {
            encapsolatedTarget.Add(character);
        }
    }

    public float GetFollowPercentage()
    {
        return followPercentage;
    }

    public void AddEncapsolateObject(Transform obj)
    {
        this.encapsolatedTarget.Add(obj);
    }

    private Vector3 GetCenterPosition(List<Transform> listOfTargets)
    {
        var bounds = new Bounds(listOfTargets[0].position, Vector3.zero);
        foreach (var target in listOfTargets)
        {
            bounds.Encapsulate(target.position);
        }
        return bounds.center;
    }

}

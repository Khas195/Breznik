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
    CharacterData playerData;
    [SerializeField]
    [Tooltip("Each frame the camera move x percentage closer to the target")]
    float followPercentage = 0.02f;
    [SerializeField]
    bool followX = false;
    [SerializeField]
    bool followY = false;
    [SerializeField]
    bool followZ = false;


    Camera mCamera;
    // Start is called before the first frame update
    void Start()
    {
        encapsolatedTarget.Add(character);
        mCamera = host.GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        if (playerData != null) {
            playerData.cameraPos =  mCamera.transform.position;
        }
    }
    void FixedUpdate()
    {
        var targetPos = GetCenterPosition(encapsolatedTarget);
        var hostPos = host.position;
        if (followX)
        {
            hostPos.x = Mathf.Lerp(hostPos.x, targetPos.x, followPercentage);
        }
        if (followY)
        {
            hostPos.y = Mathf.Lerp(hostPos.y, targetPos.y, followPercentage);
        }
        if (followZ)
        {
            hostPos.z = Mathf.Lerp(hostPos.z, targetPos.z, followPercentage);
        }
        host.transform.position = hostPos;
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
        Definition.CameraDebug("Camera Center position: " + bounds.center);
        return bounds.center;
    }

}

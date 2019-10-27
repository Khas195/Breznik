using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateMouse : MonoBehaviour
{
    [SerializeField]
    float sensitivity = 0;
    [SerializeField]
    float headUpperLimit = 0;
    [SerializeField]
    float headLowerLimit = 0;
    [SerializeField]
    Transform pitchPivot = null;
    [SerializeField]
    Transform yawnPivot = null;
    float curPitch;
    // Start is called before the first frame update
    void Start()
    { }

    // Update is called once per frame
    void Update()
    {
        var yawn = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        yawnPivot.Rotate(Vector3.up * yawn);
        var pitch = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        pitchPivot.Rotate(Vector3.left * pitch);
        curPitch = pitchPivot.localEulerAngles.x;
        if (curPitch < 180 && curPitch > headUpperLimit)
        {
            curPitch = headUpperLimit;
        }
        else if (curPitch >= 180 && curPitch < 360 + headLowerLimit)
        {
            curPitch = headLowerLimit;
        }
        pitchPivot.transform.localRotation = Quaternion.Euler(curPitch, 0, 0);
        Logger.CameraDebug("Local euler angles of pitch pivot: " + pitchPivot.localEulerAngles);
    }

}

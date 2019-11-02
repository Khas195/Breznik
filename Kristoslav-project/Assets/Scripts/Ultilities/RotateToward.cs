using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToward : MonoBehaviour
{
    [SerializeField]
    GameObject host = null;
    [SerializeField]
    GameObject target = null;
    [SerializeField]
    float rotateSpeed = 2;
    [SerializeField]
    bool rotateY = false;


    // Update is called once per frame
    void Update()
    {
        Rotate();
    }
    public void Rotate()
    {
        var direction = (target.transform.position - host.transform.position).normalized;
        if (rotateY == false) {
            direction.y = 0;
        }
        var lookRotation = Quaternion.LookRotation(direction);
        host.transform.rotation = Quaternion.Slerp(host.transform.rotation, lookRotation, rotateSpeed * Time.deltaTime);

    }

}

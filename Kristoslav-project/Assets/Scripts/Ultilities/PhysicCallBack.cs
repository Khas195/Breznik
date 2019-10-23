using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[Serializable]
public class MyTriggerEvent : UnityEvent<Collider> {
}
public class PhysicCallBack : MonoBehaviour
{
    public MyTriggerEvent triggerEnter = new MyTriggerEvent();
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit Box Touch : " + other);
        triggerEnter.Invoke(other);
    }
    
}

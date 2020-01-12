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
    public MyTriggerEvent triggerExit = new MyTriggerEvent();
    void OnTriggerEnter(Collider other)
    {
        triggerEnter.Invoke(other);
    }
    void OnTriggerExit(Collider other)
    {
        triggerExit.Invoke(other);
    }
    
}

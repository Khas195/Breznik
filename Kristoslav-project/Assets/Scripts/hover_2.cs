using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hover_2 : MonoBehaviour
{
    public float speed = 5f;
    public float distance = 5f;
   
    void Update()
    {
        //Debug.Log(Mathf.PingPong(Time.time, 15));
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * speed, distance),transform.position.z );
    }
}

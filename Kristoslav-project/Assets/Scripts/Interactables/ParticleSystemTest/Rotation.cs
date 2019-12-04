using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    Vector3 m_eulerAngle;

    

    // Start is called before the first frame update
    void Start()
    {
        m_eulerAngle = gameObject.transform.rotation.eulerAngles; 
    }

    // Update is called once per frame
    void Update()
    {
        m_eulerAngle.y = m_eulerAngle.y + rotationSpeed * Time.deltaTime;
        gameObject.transform.rotation = Quaternion.Euler(m_eulerAngle);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevitateRotate : MonoBehaviour
{
    [SerializeField]
    private Vector3 myRoationAxis;

    private float timer;

    private float fazeA, fazeB, fazeC;

    // Start is called before the first frame update
    void Start()
    {
        this.timer = 0f;
        fazeA = Random.Range(0f, 1f) * 180;
        fazeB = Random.Range(0f, 1f) * 180;
        fazeC = Random.Range(0f, 1f) * 180;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        this.myRoationAxis = new Vector3(Mathf.Sin(timer + fazeA), 
                                         5 * Mathf.Cos(timer +  fazeB), 
                                         2 * Mathf.Sin(timer + fazeC)) * 0.1f;
        this.transform.GetChild(0).Rotate(this.myRoationAxis);
    }
}

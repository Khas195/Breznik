using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reveal : MonoBehaviour
{
    private BoxCollider myCollider;
    private float timer;
    private float waitAmount;

    [SerializeField]
    private SpriteRenderer visageOfCory;

    private bool bShow;
    private bool bTime;

    // Start is called before the first frame update
    void Start()
    {
        this.myCollider = this.GetComponent<BoxCollider>();
        this.timer = 0f;
        this.waitAmount = 5f;

        this.bShow = false;
        this.bTime = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (bTime)
        {
            timer += Time.deltaTime;
            if (timer >= waitAmount)
            {
                bShow = true;
            }
        }

        if (bShow)
        {
            Color c = visageOfCory.color;
            if (c.a < 1)
            {
                c.a += Time.deltaTime;
            }
            visageOfCory.color = c;
        }
        else
        {
            Color c = visageOfCory.color;
            if (c.a > 0)
            {
                c.a -= Time.deltaTime;
            }
            visageOfCory.color = c;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.timer = 0f;
            this.bTime = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.bTime = false;
            this.bShow = false;
            this.timer = 0f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTrailController : MonoBehaviour
{
    [SerializeField]
    GameObject swordTrailObject = null;
    public void SetSwordTrail(bool on)
    {
        swordTrailObject.SetActive(on);
    }
}

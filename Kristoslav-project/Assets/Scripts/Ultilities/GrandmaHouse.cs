using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaHouse : MonoBehaviour
{
    [SerializeField]
    Collider col = null;
    int symbolActivated = 0;


    public void SymbolActivated()
    {
        symbolActivated += 1;
        if (symbolActivated >= 3)
        {
            col.enabled = true;
        }
    }
}

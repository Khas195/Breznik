using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HouseSymbol : MonoBehaviour
{
    [SerializeField]
    Color offColor = Color.red;
    [SerializeField]
    Color onColor = Color.yellow;
    Material mat = null;
    bool isOn = false;
    // Start is called before the first frame update
    void Start()
    {
        mat = this.GetComponent<Renderer>().material;
        TurnOff();
    }
    public void TurnOn()
    {
        isOn = true;
        mat.SetColor("_Color", onColor);
        mat.EnableKeyword("_EMISSION");
        mat.SetColor("_EmissionColor", onColor);
    }
    public void TurnOff()
    {
        isOn = false;
        mat.SetColor("_Color", offColor);
        mat.DisableKeyword("_EMISSION");
        mat.SetColor("_EmissionColor", offColor);
    }
    public bool IsOn()
    {
        return isOn;
    }
}

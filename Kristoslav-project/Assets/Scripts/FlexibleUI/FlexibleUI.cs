using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class FlexibleUI : MonoBehaviour
{
    [SerializeField]
    protected FlexibleUIData uIData;

    protected virtual void OnSkinUI(){

    }
    public virtual void Awake() {
    }
    public virtual void Update() {
        if (Application.isEditor) {
            OnSkinUI();
        }
    }

}

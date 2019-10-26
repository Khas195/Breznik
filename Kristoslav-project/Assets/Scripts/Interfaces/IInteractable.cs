using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class OnFocusChange : UnityEvent<IInteractable> { }
public class IInteractable : MonoBehaviour
{

    [SerializeField]
    OnFocusChange focusChanged = new OnFocusChange();
    [SerializeField]
    protected bool isFocus;
    public virtual string GetName()
    {
        return "";
    }
    public virtual void Focus(GameObject interacter)
    {
        Definition.InteractableDebug(interacter.name + " try to focus " + this.name);
        isFocus = true;
        focusChanged.Invoke(this);
    }
    public virtual void Defocus(GameObject interacter)
    {
        isFocus = false;
        focusChanged.Invoke(this);
    }

    public virtual bool Interact(GameObject interacter)
    {
        Definition.InteractableDebug(interacter.name + " try to interact with " + this.name);
        return isFocus;
    }

    public virtual GameObject GetGameObject()
    {
        return this.gameObject;
    }

    public bool IsFocus()
    {
        return isFocus;
    }

    public virtual string GetKindOfInteraction()
    {
        return "";
    }
}

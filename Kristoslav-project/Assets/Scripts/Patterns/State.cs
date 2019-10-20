using UnityEngine;
using UnityEngine.Events;

public class State : MonoBehaviour
{
    public UnityEvent OnPressedEvent;
    public UnityEvent OnPoppedEvent;
    public UnityEvent OnReturnPeekEvent;
    public UnityEvent OnPushedEvent;
    public virtual void OnPressed()
    {
        if (OnPressedEvent != null)
        {
            OnPressedEvent.Invoke();
        }
    }
    public virtual void OnPushed()
    {
        if (OnPushedEvent!= null)
        {
            OnPushedEvent.Invoke();
        }
    }
    public virtual void OnPopped()
    {
        if (OnPoppedEvent != null)
        {
            OnPoppedEvent.Invoke();
        }
    }
    public virtual void OnReturnPeek()
    {
        if (OnReturnPeekEvent!= null)
        {
            OnReturnPeekEvent.Invoke();
        }
    }
}

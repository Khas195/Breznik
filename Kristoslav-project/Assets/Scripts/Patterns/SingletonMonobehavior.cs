using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonMonobehavior<T> : MonoBehaviour where T : SingletonMonobehavior<T>
{
    static T instance;
    public static T GetInstance()
    {
        T result = null;
        try
        {
            result = (T)instance;
        }
        catch (System.InvalidCastException)
        {
            Logger.UltilitiesLog("Wrong type of singleton: " + instance);
            return null;
        }
        return result;
    }
    protected virtual void Awake()
    {
        if (instance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = (T)this;
        }

    }
}

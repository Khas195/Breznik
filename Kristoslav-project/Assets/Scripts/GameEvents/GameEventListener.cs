using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Listen to a game event that can be created in UnityEditor.
/// </summary>
public class GameEventListener : MonoBehaviour
{
    /// <summary>
    /// The Game event.
    /// </summary>
    [SerializeField]
    GameEvent Event;
    /// <summary>
    /// The reponse if the event is raised
    /// </summary>
    [SerializeField]
    UnityEvent response;
    /// <summary>
    /// Raised the event.
    /// </summary>
    public void OnEventRaised()
    {
        response.Invoke();
    }
    /// <summary>
    /// Register this listener to the event on enable.
    /// </summary>
    void OnEnable()
    {
        Event.RegisterListener(this);
    }
    /// <summary>
    /// Unregister this listener to the event on disable.
    /// </summary>
    void OnDisable()
    {
        Event.UnRegisterListener(this);
    }
}

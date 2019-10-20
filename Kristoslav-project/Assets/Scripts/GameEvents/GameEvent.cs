using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InGameEvent", menuName = "GameEvent/Event", order = 1)]
/// <summary>
/// This game event signal its listener if the event is raised.
/// </summary>
public class GameEvent : ScriptableObject
{
    /// <summary>
    /// The list of listeners
    /// </summary>
    List<GameEventListener> listeners = new List<GameEventListener>();
    /// <summary>
    /// Tell every listeners that the event is raised.
    /// </summary>
    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }
    /// <summary>
    /// Register new listener.
    /// </summary>
    /// <param name="listener">The new listener</param>
    public void RegisterListener(GameEventListener listener)
    {
        if (listeners.Contains(listener))
        {
            Definition.GameEventDebug(listener + " REGISTERING to " + this + " while ALREADY being in the list");
            return;
        }
        listeners.Add(listener);
    }
    /// <summary>
    /// Unregister the lisener.
    /// </summary>
    /// <param name="listener">The listener to be unregistered.</param>
    public void UnRegisterListener(GameEventListener listener)
    {
        if (!listeners.Contains(listener))
        {
            Definition.GameEventDebug(listener + " UNREGISTERING to " + this + " while NOT being in the list");
            return;
        }
        listeners.Remove(listener);
    }
}

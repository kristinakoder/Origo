using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GameEvent", menuName = "Scriptable Objects/GameEvent")]
public class GameEvent : ScriptableObject
{
	private List<GameEventListener> listeners = new List<GameEventListener>();
		
	public void Raise()
	{
		for(int i = listeners.Count - 1; i >= 0; i--)
			listeners[i].OnEventRaised();
	}

	//skjønner ikke helt hva man skal med disse......
	public void RegisterListener(GameEventListener listener) 
    {
        if (!listeners.Contains(listener))
            listeners.Add(listener);
    }

	public void UnregisterListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
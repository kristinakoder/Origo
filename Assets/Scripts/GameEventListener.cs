using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
		public GameEvent Event;
		public UnityEvent Response; //UnityEvent to serialize the function call as the response*
		
		private void OnEnable()
		{ Event.RegisterListener(this); }
		
		private void OnDisable()
		{ Event.UnregisterListener(this); }
		
		public void OnEventRaised()
		{ Response.Invoke(); }
}
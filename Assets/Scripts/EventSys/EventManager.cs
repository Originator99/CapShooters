using UnityEngine;

public class EventManager{
	public delegate void OnEvent(EventType type, System.Object data);
	public static event OnEvent OnEventStarted;

	public static void RaiseEvent(EventType type, System.Object data = null ){
		if (OnEventStarted != null)
			OnEventStarted (type, data);
	}
}
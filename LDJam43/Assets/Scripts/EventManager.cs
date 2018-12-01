using UnityEngine;

public class EventManager: MonoBehaviour {
	public delegate void OnLoseAction();

	public static event OnLoseAction OnLose;
}
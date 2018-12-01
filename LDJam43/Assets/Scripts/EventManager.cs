using UnityEngine;

public class EventManager: MonoBehaviour {
	public delegate void OnLoseAction();
	public delegate void OnPlayerHitAction();

	public static event OnLoseAction OnLose;
	public static event OnPlayerHitAction OnHit;

	public static void HitPlayer() {
		if (OnHit != null) {
			OnHit();
		}
	}
}
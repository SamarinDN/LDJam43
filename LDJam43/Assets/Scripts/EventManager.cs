using UnityEngine;

public class EventManager: MonoBehaviour {
	public delegate void OnLoseAction();
	public delegate void OnPlayerHitAction();

	public static event OnLoseAction OnLose;
	public static event OnPlayerHitAction OnHit;
	public static event OnPlayerHitAction OnMonsterAwake;
	public static event OnPlayerHitAction OnMonsterSleep;

	public static void HitPlayer() {
		if (OnHit != null) {
			OnHit();
		}
	}

	public static void MonsterAwake() {
		OnMonsterAwake();
	}
	
	public static void MonsterSleep() {
		OnMonsterSleep();
	}
}
using UnityEngine;

public class EventManager: MonoBehaviour {
	public delegate void OnLoseAction();
	public delegate void OnPlayerHitAction();
	public delegate void OnStolenSoulAction();
	public delegate void OnMonsterAwakeAction();
	public delegate void OnMonsterSleepAction();

	public static event OnLoseAction OnLose;
	public static event OnStolenSoulAction OnPlayerHit;
	public static event OnStolenSoulAction OnStolenSoul;
	public static event OnMonsterAwakeAction OnMonsterAwake;
	public static event OnMonsterSleepAction OnMonsterSleep;

	public static void PlayerHit() {
		if (OnPlayerHit != null) {
			OnPlayerHit();
		}
	}
	public static void StoleSoul() {
		if (OnStolenSoul != null) {
			OnStolenSoul();
		}
	}

	public static void MonsterAwake() {
		if (OnMonsterAwake != null) {
			OnMonsterAwake();
		}
	}
	
	public static void MonsterSleep() {
		if (OnMonsterSleep != null) {
			OnMonsterSleep();
		}
	}
}
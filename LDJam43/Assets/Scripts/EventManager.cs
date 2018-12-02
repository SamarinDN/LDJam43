using UnityEngine;

public class EventManager: MonoBehaviour {
	public delegate void OnLoseAction();
	public delegate void OnPlayerHitAction();
	public delegate void OnStolenSoulAction();
	public delegate void OnMonsterAwakeAction();
	public delegate void OnMonsterSleepAction();

	public static event OnLoseAction OnLose;
	public static event OnPlayerHitAction OnPlayerHit;
	public static event OnStolenSoulAction OnStolenSoul;
	public static event OnMonsterAwakeAction OnMonsterAwake;
	public static event OnMonsterSleepAction OnMonsterSleep;

	public static void Lose() {
		if (OnLose != null) {
			OnLose();
		}
	}

	public static void PlayerHit() {
		if (OnPlayerHit != null) {
			OnPlayerHit();
		}
	}
	public static void StoleSoul() {
		if (OnStolenSoul != null) {
			Debug.Log("!");
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
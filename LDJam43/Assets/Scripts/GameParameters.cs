using System.Collections;
using UnityEngine;

public class GameParameters : Singleton<GameParameters> {
	public InitData DataToInitialize;
	public float    FuelInUsage;
	
	public float    FuelInStorage;
	public float    MaxFuelInStorage;
	public int Lives;
	public float    MinFuelToGetHit;
	float           MaxFuelInUsage;
	float      _timePerTick;
	Coroutine  _gameCoroutine;
	float      _fuelDecrement = 1;

	public int GameScore {
		get { return 1337; }
	}

	void OnEnable() {
		EventManager.OnLose += StopGameProcess;
		EventManager.OnStolenSoul += StoleSoul;
		EventManager.OnPlayerHit += EatPlayer;
	}

	void OnDisable() {
		EventManager.OnLose -= StopGameProcess;
		EventManager.OnStolenSoul -= StoleSoul;
		EventManager.OnPlayerHit -= EatPlayer;
	}

	void StopGameProcess() {
		StopCoroutine(_gameCoroutine);
	}

	void StoleSoul() {
		FuelInStorage -= 10;
	}

	public void InitGameParameters() {
		FuelInUsage = DataToInitialize.FuelInUsage;
		FuelInStorage = DataToInitialize.FuelInStorage;
		Lives = DataToInitialize.Lives;
		_timePerTick = DataToInitialize.TimePerTick;
		MinFuelToGetHit = DataToInitialize.MinFuelToGetHit;
		MaxFuelInUsage = DataToInitialize.MaxFuelInUsage;
		MaxFuelInStorage = DataToInitialize.MaxFuelInStorage;
		_fuelDecrement = DataToInitialize.FuelDecrement;
	}

	public float Speed {
		get { return FuelInUsage > 0 ? FuelInUsage : 0; }
	}

	void Awake() {
		InitGameParameters();
	}

	void Start() {
		StartCoroutine(Tick());
	}

	IEnumerator Tick() {
		TickAction();
		if ( FuelInUsage < 0 ) {
			FuelInUsage = 0;
			yield return new WaitWhile(() => FuelInUsage < 0);
		}

		yield return new WaitForSeconds(_timePerTick);
		_gameCoroutine = StartCoroutine(Tick());
	}

	void TickAction() {
		FuelInUsage -= _fuelDecrement;
	}

	public void EatPlayer() {
		DealDamage(5);
	}

	public void DealDamage(int amount) {
		Lives -= amount;
		if (Lives <= 0) {
			EventManager.Lose();
		}
	}

	public void AddFuel(float amount) {
		FuelInStorage = Mathf.Min(FuelInStorage + amount, MaxFuelInStorage);
	}

	public void Feed(float amount) {
		amount = amount < FuelInStorage ? amount : FuelInStorage;
		FuelInStorage -= amount;
		FuelInUsage = Mathf.Min(amount + FuelInUsage, MaxFuelInUsage);
	}

	public void Restart() {
	}
}
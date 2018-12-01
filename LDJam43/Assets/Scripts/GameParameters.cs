using System.Collections;
using UnityEngine;

public class GameParameters : Singleton<GameParameters> {
	public InitData DataToInitialize;
	public float    FuelInUsage;
	
	public float    FuelInStorage;
	public float    MaxFuelInStorage;
	public int Lives;
	float           MaxFuelInUsage;
	float      _timePerTick;
	Coroutine  _gameCoroutine;
	float      _fuelDecrement = 1;

	void OnEnable() {
		EventManager.OnLose += StopGameProcess;
	}

	void OnDisable() {
		EventManager.OnLose -= StopGameProcess;
	}

	void StopGameProcess() {
		StopCoroutine(_gameCoroutine);
	}

	public void InitGameParameters() {
		FuelInUsage = DataToInitialize.FuelInUsage;
		FuelInStorage = DataToInitialize.FuelInStorage;
		Lives = DataToInitialize.Lives;
		_timePerTick = DataToInitialize.TimePerTick;
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

	public void DealDamage(int amount) {
		Lives -= amount;
	}

	public void AddFuel(float amount) {
		FuelInStorage = Mathf.Min(FuelInStorage + amount, MaxFuelInStorage);
	}

	public void Feed(float amount) {
		amount = amount < FuelInStorage ? amount : FuelInStorage;
		FuelInStorage -= amount;
		FuelInUsage = Mathf.Min(amount + FuelInUsage, MaxFuelInUsage);
	}
}
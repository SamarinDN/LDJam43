using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Lifetime;
using UnityEngine;

public class GameParameters : Singleton<GameParameters> {
	public InitData DataToInitialize;
	public float    FuelInUsage;
	float           MaxFuelInUsage;
	public float    FuelInStorage;
	public float    MaxFuelInStorage;

	public int Lives;
	float      TimePerTick;

	Coroutine GameCoroutine;

	float fuelDecrement = 1;

	void OnEnable() {
		EventManager.OnLose += StopGameProcess;
	}

	void StopGameProcess() {
		StopCoroutine(GameCoroutine);
	}

	public void InitGameParameters() {
		FuelInUsage = DataToInitialize.FuelInUsage;
		FuelInStorage = DataToInitialize.FuelInStorage;
		Lives = DataToInitialize.Lives;
		TimePerTick = DataToInitialize.TimePerTick;
		MaxFuelInUsage = DataToInitialize.MaxFuelInUsage;
		MaxFuelInStorage = DataToInitialize.MaxFuelInStorage;
		MaxFuelInUsage = DataToInitialize.MaxFuelInUsage;
		fuelDecrement = DataToInitialize.fuelDecrement;
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

		yield return new WaitForSeconds(TimePerTick);
		GameCoroutine = StartCoroutine(Tick());
	}

	void TickAction() {
		FuelInUsage -= fuelDecrement;
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
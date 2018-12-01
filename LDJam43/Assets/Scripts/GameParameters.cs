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


	float fuelDecrement = 1;

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
		get { return FuelInUsage; }
	}

	void Awake() {
		InitGameParameters();
	}

	void Start() {
		StartCoroutine(Tick());
	}

	IEnumerator Tick() {
		TickAction();
		if ( FuelInStorage <= 0 ) {
			FuelInStorage = 0;
			yield return new WaitWhile(() => FuelInStorage <= 0);
		}

		yield return new WaitForSeconds(TimePerTick);
		StartCoroutine(Tick());
	}

	void TickAction() {
		FuelInUsage -= fuelDecrement;
	}

	public void DealDamage(int lives) {
		Lives -= lives;
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
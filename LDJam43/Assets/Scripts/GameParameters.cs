using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Lifetime;
using UnityEngine;

public class GameParameters : Singleton<GameParameters> {
	public float FuelInUsage = 70;
	public float FuelInStorage=300;
	public int   Lives       = 5;
	public float TimePerTick = 1;
	public float MaxFuel=100;

	public float Speed {
		get { return FuelInStorage; }
	}

	void Start() {
		StartCoroutine(Tick());
	}

	IEnumerator Tick() {
		TickAction();
		yield return new WaitForSeconds(TimePerTick);
		StartCoroutine(Tick());
	}

	void TickAction() {
		FuelInUsage -= 1;
	}

	public void DealDamage(int lives) {
		Lives -= lives;
	}

	public void Feed(float amount) {
		amount = amount < FuelInStorage ? amount : FuelInStorage;
		FuelInStorage -= amount;
		FuelInUsage = Mathf.Min(amount + FuelInUsage, MaxFuel);
	}
}
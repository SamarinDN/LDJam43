using System.Collections.Generic;
using UnityEngine;

public class FuelManager : Singleton<FuelManager> {

	[SerializeField]
	GameObject _fuelsPool;

	List<Fuel> _fuels;

	void Start() {
		var fuels = _fuelsPool.GetComponentsInChildren<Fuel>();
		_fuels = new List<Fuel>(fuels);
	}

	public void SpawnFeed(Vector3 position) {
		var fuel = _fuels.Find(u => u.IsMove == false);
		if (fuel) {
			fuel.Reset();
			fuel.transform.position = position;
		}
	}
}
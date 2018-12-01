using System.Collections.Generic;
using UnityEngine;

public class FoodManager : Singleton<FoodManager> {

	[SerializeField] private GameObject _foodsPool;

	private List<Food> _foods;

	private void Start() {
		var foods = _foodsPool.GetComponentsInChildren<Food>();
		_foods = new List<Food>(foods);
	}

	public void SpawnFeed(Vector3 position) {
		var food = _foods.Find(u => u.IsMove == false);
		if (food) {
			food.transform.position = position;
		}
	}
}
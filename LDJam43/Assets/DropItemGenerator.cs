using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemGenerator : Singleton<DropItemGenerator> {
	public GameObject[] ItemPrefabs;

	public List<DropItem> DisabledItems;

	void Awake() {
		DisabledItems = new List<DropItem>();
		for ( int i = 0; i < 30; i++ ) {
			DisabledItems.Add(InstantiateItemFromPrefab().GetComponent<DropItem>());
		}

		foreach ( var dropItem in DisabledItems ) {
			dropItem.gameObject.SetActive(false);
		}
	}


	public void InitItem(Transform transform) {
		if ( DisabledItems.Count > 0 ) {
			var curr = DisabledItems[Random.Range(0, DisabledItems.Count)];
			curr.gameObject.SetActive(true);
			DisabledItems.RemoveAt(0);
			curr.Init(transform);
		}
		else {
			InstantiateItemFromPrefab().GetComponent<DropItem>().Init(transform);
		}
	}

	GameObject InstantiateItemFromPrefab() {
		var enemy = Instantiate(ItemPrefabs[Random.Range(0, ItemPrefabs.Length)],
			Vector3.zero,
			Quaternion.identity, transform);
		var manager = enemy.GetComponent<DropItem>();
		manager.DropItemGenerator = this;
		return manager.gameObject;
	}
}
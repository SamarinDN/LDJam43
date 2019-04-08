using UnityEngine;

public class Fuel : DropItem {
	[SerializeField] public bool IsMove;

	void Start() {
		IsMove = false;
	}
}

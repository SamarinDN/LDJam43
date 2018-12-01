using UnityEngine;

public class Fuel : DropItem {
	[SerializeField] public bool IsMove;

	private void Start() {
		IsMove = false;
	}
}

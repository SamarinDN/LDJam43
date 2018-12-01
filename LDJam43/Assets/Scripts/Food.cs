using UnityEngine;

public class Food : DropItem {
	[SerializeField] public bool IsMove;

	private void Start() {
		IsMove = false;
	}
}

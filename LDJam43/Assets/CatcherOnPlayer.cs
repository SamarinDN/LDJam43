using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatcherOnPlayer : MonoBehaviour {

int 	Health=5;
	public float reduceAmount;
	void OnEnable() {
		Health = 5;
		ReduceFuel(25f);
	}

	void OnDisable() {
	}

	public void ReduceFuel(float amount) {
		reduceAmount=GameParameters.Instance.ReduceFuelInUsage(amount);
	}

	public void Tap() {
		Health--;
		if ( Health<=0 ) {
			gameObject.SetActive(false);
		}
	}
}

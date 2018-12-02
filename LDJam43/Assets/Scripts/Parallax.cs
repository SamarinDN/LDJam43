using System;
using System.Collections.Generic;
using UnityEngine;

public enum ParallaxType {
	Ice,
	Back,
	Water
}

public class Parallax : MonoBehaviour {
	float        _pos  = 0;
	public  float        Delta = 0;
	public  ParallaxType ParallaxType;

	private List<DropItem> _souls = new List<DropItem>();

	public float Multiplier {
		get {
			switch ( ParallaxType ) {
				case ParallaxType.Ice:
					return GameParameters.Instance.DataToInitialize.IceSpeedMultiplier;
				case ParallaxType.Back:
					return GameParameters.Instance.DataToInitialize.BackSpeedMultiplier;
				case ParallaxType.Water:

					return GameParameters.Instance.DataToInitialize.WaterSpeedMultiplier;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}

	void FixedUpdate() {
		_pos += GameParameters.Instance.Speed /(Multiplier*100);
		MoveSouls(_pos);
		if ( _pos > Delta ) {
			_pos -= Delta;
		}

		transform.position = new Vector3(-_pos, transform.position.y);
	}

	void MoveSouls(float delta) {
		foreach (var s in _souls) {
			s.transform.position = new Vector3(-_pos, transform.position.y);
		}
	}

	public void AddSoul() {
	}

	public void RemoveSoul() {
	}
}
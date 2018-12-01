using System;
using UnityEngine;

public enum ParallaxType {
	Ice,
	Back,
	Water
}

public class Parallax : MonoBehaviour {
	private float        _pos  = 0;
	public  float        Delta = 0;
	public  ParallaxType ParallaxType;

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
		if ( _pos > Delta ) {
			_pos -= Delta;
		}

		transform.position = new Vector3(-_pos, transform.position.y);
	}
}
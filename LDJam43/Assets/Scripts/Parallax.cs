using UnityEngine;

public class Parallax : MonoBehaviour {

	private float _pos = 0;
	public float Delta = 0;

	void FixedUpdate() {
		_pos += GameParameters.Instance.Speed /GameParameters.Instance.DataToInitialize.BackSpeedMultiplier;
		if (_pos > Delta) {
			_pos -= Delta;
		}
		transform.position = new Vector3(-_pos, transform.position.y);
	}
}
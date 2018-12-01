using UnityEngine;

public class Parallax : MonoBehaviour {

	[SerializeField] private Transform _image;
	private float _pos = 0;
	public float Delta = 0;
	public float Speed = 0;

	void FixedUpdate() {
		// TODO
		_pos += Speed;
		if (_pos > Delta) {
			_pos -= Delta;
		}
		_image.position = new Vector3(-_pos, _image.position.y);
	}
}
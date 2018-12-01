using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ResetableRigitbody2D : MonoBehaviour {
	protected Rigidbody2D _rigidbody2D;
	

	void Awake() {
		_rigidbody2D = GetComponent<Rigidbody2D>();
	}

	public void Reset() {
		_rigidbody2D.velocity = new Vector3(0f,0f,0f); 
		_rigidbody2D.angularVelocity = 0;
		transform.rotation = Quaternion.Euler(new Vector3(0f,0f,0f));
	}
}
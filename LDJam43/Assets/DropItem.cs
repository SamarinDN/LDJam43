using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropItem : ResetableRigitbody2D, IPointerClickHandler {
	Coroutine _updateCoroutine;
	InitData  _initData;

	void Awake() {
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_rigidbody2D.AddForce(Vector2.left * (GameParameters.Instance.Speed *
		                                      GameParameters.Instance.DataToInitialize.DropItemSpeedMultiplier));
		_initData = GameParameters.Instance.DataToInitialize;
	}

	void OnEnable() {
		//_updateCoroutine = StartCoroutine(UpdateVelocity());
	}

	void OnDisable() {
		//StopCoroutine(_updateCoroutine);
	}

	IEnumerator UpdateVelocity() {
		_rigidbody2D.velocity =
			new Vector2(
				-GameParameters.Instance.Speed / _initData.DropItemSpeedMultiplier,
				_rigidbody2D.velocity.y);
		yield return new WaitForSeconds(_initData.TimePerTick);
		StartCoroutine(UpdateVelocity());
	}

	public void OnPointerClick(PointerEventData eventData) {
		GameParameters.Instance.AddFuel(_initData.DropItemReward);

		Reset();
		gameObject.SetActive(false);
	}
}
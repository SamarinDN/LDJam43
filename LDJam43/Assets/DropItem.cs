using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropItem : MonoBehaviour, IPointerClickHandler {
	InitData                 _initData;
	public DropItemGenerator DropItemGenerator;

	void Awake() {
		_initData = GameParameters.Instance.DataToInitialize;
	}

	public void Init(Transform NewTransform) {
		transform.position = NewTransform.position;
	}

	public void OnPointerClick(PointerEventData eventData) {
		GameParameters.Instance.AddFuel(_initData.DropItemReward);
		DropItemGenerator.DisabledItems.Add(this);
		gameObject.SetActive(false);
	}
}
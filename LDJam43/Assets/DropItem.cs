using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropItem : MonoBehaviour, IPointerClickHandler {
	public DropItemGenerator DropItemGenerator;


	public void Init(Transform NewTransform) {
		transform.position = NewTransform.position;
	}

	public void OnPointerClick(PointerEventData eventData) {
		GameParameters.Instance.AddFuel(GameParameters.Instance.DropItemReward);
		DropItemGenerator.DisabledItems.Add(this);
		gameObject.SetActive(false);
	}
}
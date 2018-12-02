
using Units;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyTappable : MonoBehaviour,IPointerClickHandler {
	public EnemyGenerator EnemyGenerator;
	
	public void OnPointerClick(PointerEventData eventData) {
		OnClickAction();
	}

	protected virtual void OnClickAction() {
		
		
	}
	
}

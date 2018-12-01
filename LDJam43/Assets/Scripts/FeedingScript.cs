using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FeedingScript : MonoBehaviour,IPointerClickHandler{

	public void OnPointerClick(PointerEventData eventData) {
		Debug.Log("CLIIICK");
		GameParameters.Instance.Feed(10);
	}
}

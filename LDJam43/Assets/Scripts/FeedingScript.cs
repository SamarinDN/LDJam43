using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FeedingScript : MonoBehaviour,IPointerClickHandler{

	public void OnPointerClick(PointerEventData eventData) {
		GameParameters.Instance.Feed(GameParameters.Instance.DataToInitialize.FeedingCost);
	}
}

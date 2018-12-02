using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FeedingScript : MonoBehaviour, IPointerClickHandler {
	public List<CatcherOnPlayer> CatchersOnPlayer;

	void OnEnable() {
		EventManager.OnCatcherAttacked+=TryActivateCatcher;
	}

	void TryActivateCatcher() {
		foreach ( var catcherOnPlayer in CatchersOnPlayer ) {
			if ( !catcherOnPlayer.gameObject.activeInHierarchy ) {
				
				catcherOnPlayer.gameObject.SetActive(true);
				return;
			}
		}
	}

	public void OnPointerClick(PointerEventData eventData) {
		var catcher = IsAnyCatchers();
		if ( catcher ) {
			catcher.Tap();
			return;
		}

		GameParameters.Instance.Feed(GameParameters.Instance.DataToInitialize.FeedingCost);
	}

	CatcherOnPlayer IsAnyCatchers() {
		foreach ( var catcherOnPlayer in CatchersOnPlayer ) {
			if ( catcherOnPlayer.isActiveAndEnabled ) {
				return catcherOnPlayer;
			}
		}

		return null;
	}
}
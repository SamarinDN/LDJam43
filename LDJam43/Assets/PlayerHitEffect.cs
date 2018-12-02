using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitEffect : MonoBehaviour {
	BoxCollider2D _collider2D;

	void Awake() {
		_collider2D = GetComponent<BoxCollider2D>();
	}

	IEnumerator CheckCollide() {
		while ( true ) {
			
		
		yield return new WaitForSeconds(0.2f);
		foreach ( var other in Physics2D.OverlapBoxAll((Vector2) transform.position + _collider2D.offset,
			_collider2D.size, 0f) ) {
			if ( !other.CompareTag("Player") ) continue;
			EventManager.StoleSoul();
		//	_image.sprite = _beforePlayerHit;
			yield break;
		}}
	}
}

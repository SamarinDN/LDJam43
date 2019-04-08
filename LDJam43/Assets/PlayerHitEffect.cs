using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitEffect : MonoBehaviour {
	BoxCollider2D _collider2D;

	[SerializeField] private SpriteRenderer _sprite;
		Coroutine coroutine;
	void Awake() {
		_collider2D = GetComponent<BoxCollider2D>();
	}

	void OnEnable() {
		coroutine = StartCoroutine(CheckCollider());
		_sprite.gameObject.SetActive(false);
	}

	void OnDisable() {
		if ( coroutine != null ) StopCoroutine(coroutine);
	}

	IEnumerator CheckCollider() {
		while ( true ) {
			yield return new WaitForSeconds(0.2f);
			foreach ( var other in Physics2D.OverlapBoxAll((Vector2) transform.position + _collider2D.offset,
				_collider2D.size, 0f) ) {
				if ( !other.CompareTag("Player") ) continue;
				EventManager.StoleSoul();
				_sprite.gameObject.SetActive(true);
				//	_image.sprite = _beforePlayerHit;
				yield break;
			}
		}
	}
}
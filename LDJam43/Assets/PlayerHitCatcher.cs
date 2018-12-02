using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitCatcher : MonoBehaviour {

	BoxCollider2D _collider2D;

	Coroutine coroutine;
	void Awake() {
		_collider2D = GetComponent<BoxCollider2D>();
	}

	void OnEnable() {
		coroutine = StartCoroutine(CheckCollider());
	}

	void OnDisable() {
		if ( coroutine != null ) StopCoroutine(coroutine);
	}

	IEnumerator CheckCollider() {
		while ( true ) {
			yield return new WaitForSeconds(0.2f);
			foreach ( var other in Physics2D.OverlapBoxAll((Vector2) transform.position + _collider2D.offset,
				_collider2D.size, 0f) ) {
				if ( !other.CompareTag("PlayerBody") ) continue;
				EventManager.CatcherAttacked();
				GetComponent<EnemyTappable>().EnemyGenerator.DisabledEnemies.Add(gameObject.GetComponent<EnemyMoving>());
				gameObject.SetActive(false);
				yield break;
			}
		}
	}
}

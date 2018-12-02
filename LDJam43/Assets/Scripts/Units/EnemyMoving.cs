using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyMoving : MonoBehaviour {
	BoxCollider2D  _collider;

	public virtual void Init() {
		DOTween.Init();
		_collider = GetComponent<BoxCollider2D>();
	}

	private void OnEnable() {
		StartCoroutine(CheckCollide());
	}

	private void OnDisable() {
		StopAllCoroutines();
	}

	IEnumerator CheckCollide() {
		yield return new WaitForSeconds(0.2f);
		foreach ( var other in Physics2D.OverlapBoxAll((Vector2) transform.position + _collider.offset,
			_collider.size, 0f) ) {
			if ( !other.CompareTag("Player") ) continue;
			EventManager.StoleSoul();
			//TODO change image
			yield break;
		}

		StartCoroutine(CheckCollide());
	}
}

using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovingUnit : MonoBehaviour, IPointerClickHandler {
	List<Vector3> _points;
	SpriteRenderer _image;
	BoxCollider2D  _collider;
	[SerializeField]
	Sprite _afterPlayerHit;
	[SerializeField]
	Sprite _beforePlayerHit;

	protected void Start() {
		_image = GetComponent<SpriteRenderer>();
		_collider = GetComponent<BoxCollider2D>();
		_image.sprite = _afterPlayerHit;
		Init();
	}

	public void OnPointerClick(PointerEventData eventData) {
		FuelManager.Instance.SpawnFeed(transform.position);
		transform.DOComplete();
	}

	void OnEnable() {
		StartCoroutine(CheckCollide());
	}


	public void ClearPoint() {
		_points.Clear();
	}

	public void AddPoint(Vector3 point) {
		_points.Add(point);
	}

	protected void Init() {
		DOTween.Init();
		_points = new List<Vector3>();
		gameObject.SetActive(false);
	}

	public void Run(float duration) {
		gameObject.SetActive(true);
		_image.sprite = _afterPlayerHit;
		transform.DOPath(_points.ToArray(), duration, PathType.CatmullRom).onComplete = () => {
			gameObject.SetActive(false);
		};
	}

	IEnumerator CheckCollide() {
		yield return new WaitForSeconds(0.2f);
		foreach ( var other in Physics2D.OverlapBoxAll((Vector2) transform.position + _collider.offset,
			_collider.size, 0f) ) {
			if ( !other.CompareTag("Player") ) continue;
			EventManager.StoleSoul();
			_image.sprite = _beforePlayerHit;
			yield break;
		}

		StartCoroutine(CheckCollide());
	}
}
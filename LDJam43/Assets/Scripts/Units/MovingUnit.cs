using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovingUnit : MonoBehaviour, IPointerClickHandler {

	private List<Vector3> _points;

	private SpriteRenderer _image;
	private BoxCollider2D _collider;
	[SerializeField] private Sprite _afterPlayerHit;
	[SerializeField] private Sprite _beforePlayerHit;

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

	private void OnEnable() {
		StartCoroutine(CheckCollide());
	}

	private void OnDisable() {
		StopAllCoroutines();
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
	
	private IEnumerator CheckCollide()
	{
		yield return new WaitForSeconds(0.2f);
		foreach (var other in Physics2D.OverlapBoxAll((Vector2) transform.position +  _collider.offset,
			_collider.size, 0f))
		{
			if (other.CompareTag("Player")) {
				EventManager.StoleSoul();
				_image.sprite = _beforePlayerHit;
				StopAllCoroutines();
				yield break;
			}
		}

		StartCoroutine(CheckCollide());
	}
}

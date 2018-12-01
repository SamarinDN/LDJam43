using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovingUnit : MonoBehaviour, IPointerClickHandler {

	private List<Vector3> _points;

	[SerializeField] public bool IsMove;// { get; private set; }
	[SerializeField] public bool IsHitPlayer;

	private BoxCollider2D _collider;
	protected void Start() {
		IsMove = false;
		_collider = GetComponent<BoxCollider2D>();
		Init();
	}

	public void OnPointerClick(PointerEventData eventData) {
		Debug.Log("Kill Bird");
		FoodManager.Instance.SpawnFeed(transform.position);
		transform.DOComplete();
		IsMove = false;
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
	}

	public void Run(float duration) {
		IsMove = true;
		transform.DOPath(_points.ToArray(), duration, PathType.CatmullRom).onComplete = () => {
			IsMove = false;
		};
	}

	private void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("!");
	}
}

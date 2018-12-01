using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovingUnit : MonoBehaviour, IPointerClickHandler {

	private List<Vector3> _points;

	private SpriteRenderer _image;
	[SerializeField] private Sprite _afterPlayerHit;
	[SerializeField] private Sprite _beforePlayerHit;

	[SerializeField] public bool IsMove;// { get; private set; }

	protected void Start() {
		IsMove = false;
		_image = GetComponent<SpriteRenderer>();
		_image.sprite = _afterPlayerHit;
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
		_image.sprite = _afterPlayerHit;
		IsMove = true;
		transform.DOPath(_points.ToArray(), duration, PathType.CatmullRom).onComplete = () => {
			IsMove = false;
		};
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name != "Engine") {
			return;
		}
		EventManager.HitPlayer();
		_image.sprite = _beforePlayerHit;
	}
}

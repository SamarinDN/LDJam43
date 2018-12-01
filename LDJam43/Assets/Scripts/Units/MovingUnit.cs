using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovingUnit : MonoBehaviour, IPointerClickHandler {

	private List<Vector3> _points;

	public bool IsMove { get; private set; }

	protected void Start() {
		IsMove = false;
		Init();
	}

	public void OnPointerClick(PointerEventData eventData) {
		Debug.Log("Kill Bird");
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
}

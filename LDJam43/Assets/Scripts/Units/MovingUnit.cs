using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovingUnit : MonoBehaviour, IPointerClickHandler {

	[SerializeField] protected List<PathPoint> Points;

	private int _pointIndex = 0;
	
	private void Start() {
		DOTween.Init();
		Move();
	}

	public void OnPointerClick(PointerEventData eventData) {
		Debug.Log("Kill Bird");
	}

	private void Move() {
		if (_pointIndex < Points.Count) {
			var point = Points[_pointIndex].Point.transform.position;
			var time = Points[_pointIndex].Time;
			MoveToPoint(point, time).onComplete = Move;
			_pointIndex++;
		}
	}

	private Tween MoveToPoint(Vector3 point, float time) {
		return transform.DOMove(point, time);
	}

	[Serializable]
	public class PathPoint {
		[SerializeField] public GameObject Point;
		[SerializeField] public float Time;
	}
}

using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Units;
using UnityEngine;

public class AngelMoving : EnemyMoving {
	readonly List<Vector3> _points = new List<Vector3>();
	[SerializeField] private PathGenerator _pathGenerator;
	private float _duration;

	public override void Init() {
		base.Init();
		gameObject.SetActive(true);
		AddPath(_pathGenerator.GetPath());
		SetSpeed(10);
		transform.DOPath(_points.ToArray(), _duration, PathType.CatmullRom).onComplete = () => {
			gameObject.SetActive(false);
		};
	}

	public void SetSpeed(float duration) {
		_duration = duration;
	}

	public void AddPath(List<Vector3> points) {
		_points.Clear();
		foreach (var p in points) {
			_points.Add(p);
		}
	}
}

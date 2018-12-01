using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ChinMove : MonoBehaviour {
	public Transform MidPos;
	public Transform FinalPos;
	public float       Duration = 1;

	void Start() {
		var q = MidPos.rotation;
		//transform.DOMoveY(transform.position.y-0.1f, 1).SetLoops(-1,LoopType.Yoyo);

		transform.DOPath(new[] {
			MidPos.position,
			FinalPos.position
		}, Duration).SetLoops(-1, LoopType.Yoyo);
		transform.DORotateQuaternion(
			FinalPos.rotation
			, Duration).SetLoops(-1, LoopType.Yoyo);
	}
}
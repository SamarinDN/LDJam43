using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CatcherMoveable : EnemyMoving {
	public Transform InitPos;
	public Transform EndPOs;
	
	public override void Init() {
		base.Init();
		transform.position = InitPos.position;
		transform.DOMove(EndPOs.position, 5);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelTappable : EnemyTappable {
	protected override void OnClickAction() {
		DropItemGenerator.Instance.InitItem(transform);
		gameObject.SetActive(false);
		EnemyGenerator.DisabledEnemies.Add(GetComponent<EnemyMoving>());
	}
}

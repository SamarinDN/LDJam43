using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatcherTappable : EnemyTappable {

	protected override void OnClickAction() {
		gameObject.SetActive(false);
		EnemyGenerator.DisabledEnemies.Add(GetComponent<EnemyMoving>());
	}
}

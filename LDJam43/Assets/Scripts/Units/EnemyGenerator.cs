using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {
	public GameObject[] EnemyPrefabs;

	public List<EnemyMoving> DisabledEnemies;

	void Awake() {
		DisabledEnemies = new List<EnemyMoving>();
		for ( int i = 0; i < 30; i++ ) {
			DisabledEnemies.Add(InstantiateEnemyFromPrefab().GetComponent<EnemyMoving>());
		}

		foreach ( var disabledEnemy in DisabledEnemies ) {
			disabledEnemy.gameObject.SetActive(false);
		}
	}

	void OnEnable() {
		EventManager.InitEnemy += InitEnemy;
		StartCoroutine(asdasd());
		StartCoroutine(spawnHand());
	}

	IEnumerator asdasd() {
		while ( true ) {
			yield return new WaitForSeconds(3f);
			EventManager.SpawnEnemy();
		}
	}

	IEnumerator spawnHand() {
		while ( true ) {
			yield return new WaitForSeconds(20f);
			EventManager.MonsterAwake();
		}
	}

	void InitEnemy() {
		if ( DisabledEnemies.Count > 0 ) {
			var curr = DisabledEnemies[Random.Range(0, DisabledEnemies.Count)];
			curr.gameObject.SetActive(true);
			DisabledEnemies.RemoveAt(0);
			curr.Init();
		}
		else {
			InstantiateEnemyFromPrefab().GetComponent<EnemyMoving>().Init();
		}
	}

	GameObject InstantiateEnemyFromPrefab() {
		var enemy = Instantiate(EnemyPrefabs[Random.Range(0, EnemyPrefabs.Length)],
			transform.position,
			Quaternion.identity, transform);
		var manager = enemy.GetComponent<EnemyTappable>();
		manager.EnemyGenerator = this;
		return manager.gameObject;
	}

	public void test() {
		EventManager.SpawnEnemy();
	}
	
	public void test2() {
		EventManager.MonsterAwake();
	}
}
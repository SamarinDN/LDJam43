using System;
using System.Collections;
using System.Collections.Generic;
using Units;
using UnityEngine;
using UnityEngine.Networking;
using Random = UnityEngine.Random;

public class GameEventManager : MonoBehaviour {

	[SerializeField] private UnitsGeneratorSetting _fishGenerators;
	[SerializeField] private UnitsGeneratorSetting _shellGenerators;
	[SerializeField] private UnitsGeneratorSetting _birdGenerators;
	// TODO FuelGeneratorSetting;
	// TODO MonsterGeneratorSetting;

	[SerializeField] private float _loopTime;
	
	private float _monsterTimer = 0;
	private float _fishTimer = 0;
	private float _shellTimer = 0;
	private float _birdTimer = 0;

	public enum Stages {
		Tutorial_Life,
		Tutorial_Speed,
		Tutorial_Fuel,
		Tutorial_Shell,
		Tutorial_Fish,
		Tutorial_Bird,
		Loop,
	}

	private Stages _stage = Stages.Loop;// Stages.Tutorial_Life;

	public void Update() {
		if (_stage == Stages.Loop) {
			TrySpawnMonster();
			TrySpawnFish();
			TrySpawnShell();
			TrySpawnBird();
		}
	}

	public void NextStage() {
		// TODO
	}

	protected void TutorialA() {
	}
	
	protected void TutorialB() {
	}
	
	protected void TutorialC() {
	}
	
	protected void TutorialD() {
	}

	private void TrySpawnMonster() {
		_monsterTimer -= Time.deltaTime;
		if (!(_monsterTimer <= 0.0f)) {
			return;
		}
		_monsterTimer = _loopTime;
		// TODO Spawn Monster
	}
	
	private void TrySpawnFish() {
		_fishTimer -= Time.deltaTime;
		if (!(_fishTimer <= 0.0f)) {
			return;
		}
		_fishTimer = _fishGenerators.GetSpawnRate();
		_fishGenerators.SpawnUnit();
	}
	
	private void TrySpawnShell() {
		_shellTimer -= Time.deltaTime;
		if (!(_shellTimer <= 0.0f)) {
			return;
		}
		_shellTimer = _shellGenerators.GetSpawnRate();
		_shellGenerators.SpawnUnit();
	}

	private void TrySpawnBird() {
		_birdTimer -= Time.deltaTime;
		if (!(_birdTimer <= 0.0f)) {
			return;
		}
		_birdTimer = _birdGenerators.GetSpawnRate();
		_birdGenerators.SpawnUnit();
	}

	private void NextLoop() {
		_fishGenerators.ChangeSpawnRate();
		_shellGenerators.ChangeSpawnRate();
		_birdGenerators.ChangeSpawnRate();

		_fishGenerators.ChangeSpeed();
		_shellGenerators.ChangeSpeed();
		_birdGenerators.ChangeSpeed();
	}

	[Serializable]
	class UnitsGeneratorSetting {
		[SerializeField] private UnitsGenerator _unitGenerator;
		[SerializeField] private float _spawnRate;
		[SerializeField] private float _spawnDelta;
		[SerializeField] private float _spawnScale;
		
		[SerializeField] private float _speed;
		[SerializeField] private float _speedDelta;
		[SerializeField] private float _speedScale;

		public void SpawnUnit() {
			_unitGenerator.LaunchUnit(Random.Range(_speed, _speed + _speedDelta));
		}

		public void ChangeSpawnRate() {
			_spawnRate *= _spawnScale;
		}
		
		public void ChangeSpeed() {
			_speed *= _speedScale;
		}

		public float GetSpawnRate() {
			return Random.Range(_spawnRate, _spawnRate + _spawnDelta);
		}
	}
}
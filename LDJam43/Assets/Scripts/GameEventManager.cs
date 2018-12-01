using System;
using System.Collections;
using System.Collections.Generic;
using Units;
using UnityEngine;
using UnityEngine.Networking;
using Random = UnityEngine.Random;

public class GameEventManager : MonoBehaviour {

	[SerializeField] private List<UnitsGeneratorSetting> _uintGenerators;
	[SerializeField] private Monster _monster;

	// TODO FuelGeneratorSetting;

	[SerializeField] private float _loopTime;
	
	private float _monsterTimer = 0;

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

	private void Start() {
		foreach (var g in _uintGenerators) {
			g.Init();
		}
	}

	private void Update() {
		if (_stage == Stages.Loop) {
			foreach (var g in _uintGenerators) {
				g.TrySpawnUnit();
			}
			TrySpawnMonster();
		}
	}

	public void NextStage() {
		// TODO
	}

	protected void TutorialLife() {
		// TODO
	}
	
	protected void TutorialSpeed() {
		// TODO
	}
	
	protected void TutorialFuel() {
		// TODO
	}
	
	protected void TutorialShell() {
		// TODO
	}
	
	protected void TutorialFish() {
		// TODO
	}
	
	protected void TutorialBird() {
		// TODO
	}

	private void TrySpawnMonster() {
		_monsterTimer -= Time.deltaTime;
		if (!(_monsterTimer <= 0.0f)) {
			return;
		}
		_monsterTimer = _loopTime;
		_monster.Spawn();
		NextLoop();
	}

	private void NextLoop() {
		foreach (var g in _uintGenerators) {
			g.ChangeSpawnRate();
			g.ChangeSpeed();
		}
	}

	[Serializable]
	class UnitsGeneratorSetting {
		[SerializeField] private UnitsGenerator _unitGenerator;
		[SerializeField] private UnitsGeneratorSettingData _settingData;
		
		private float _spawnRate;
		private float _spawnDelta;
		private float _spawnScale;
		
		private float _speed;
		private float _speedDelta;
		private float _speedScale;
		
		private float _timer = 0;

		public void Init() {
			_spawnRate = _settingData.SpawnRate;
			_spawnDelta = _settingData.SpawnDelta;
			_spawnScale = _settingData.SpawnScale;
			_speed = _settingData.Speed;
			_speedDelta = _settingData.SpeedDelta;
			_speedScale = _settingData.SpeedScale;
			_timer = Random.Range(0, _spawnRate + _spawnDelta);
		}

		public void SpawnUnit() {
			_unitGenerator.LaunchUnit(Random.Range(_speed, _speed + _speedDelta));
		}

		public void ChangeSpawnRate() {
			_spawnRate *= _spawnScale;
		}
		
		public void ChangeSpeed() {
			_speed *= _speedScale;
		}
		
		public void TrySpawnUnit() {
			if (_unitGenerator == null) {
				return;
			}
			_timer -= Time.deltaTime;
			if (!(_timer <= 0.0f)) {
				return;
			}
			_timer = Random.Range(_spawnRate, _spawnRate + _spawnDelta);
			SpawnUnit();
		}
	}
}
using System;
using System.Collections;
using System.Collections.Generic;
using Units;
using UnityEngine;
using UnityEngine.Networking;
using Random = UnityEngine.Random;

public class GameEventManager : MonoBehaviour {

	[SerializeField]
	List<UnitsGeneratorSetting> _uintGenerators;

	// TODO FuelGeneratorSetting;

	[SerializeField]
	float _loopTime;

	float _monsterTimer = 0;

	public enum Stages {
		Tutorial_Life,
		Tutorial_Speed,
		Tutorial_Fuel,
		Tutorial_Shell,
		Tutorial_Fish,
		Tutorial_Bird,
		Loop,
	}

	Stages _stage = Stages.Loop;// Stages.Tutorial_Life;

	void Start() {
		foreach (var g in _uintGenerators) {
			g.Init();
		}
	}

	void Update() {
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

	void TrySpawnMonster() {
		_monsterTimer -= Time.deltaTime;
		if (!(_monsterTimer <= 0.0f)) {
			return;
		}
		_monsterTimer = _loopTime;
		EventManager.MonsterAwake();
		NextLoop();
	}

	void NextLoop() {
		foreach (var g in _uintGenerators) {
			g.ChangeSpawnRate();
			g.ChangeSpeed();
		}
	}

	[Serializable]
	class UnitsGeneratorSetting {
		[SerializeField]
		UnitsGenerator _unitGenerator;
		[SerializeField]
		UnitsGeneratorSettingData _settingData;

		float _spawnRate;
		float _spawnDelta;
		float _spawnScale;

		float _speed;
		float _speedDelta;
		float _speedScale;

		float _timer = 0;

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
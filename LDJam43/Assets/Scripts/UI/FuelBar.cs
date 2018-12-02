using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
	public class FuelBar : MonoBehaviour {

		public InitData DataToInitialize;
		[SerializeField]
		Image _fuelBar;
		[SerializeField]
		Image _usageFuelBar;
		
		[SerializeField]
		Image _monsterMarker;

		Vector2 _fuelBarSize;
		Vector2 _usageFuelBarSize;

		float _maxFuelInStorage;
		float _maxFuelInUsage;
		
		public void Start() {
			_fuelBarSize = _fuelBar.rectTransform.sizeDelta;
			_usageFuelBarSize = _usageFuelBar.rectTransform.sizeDelta;
			_maxFuelInStorage = DataToInitialize.MaxFuelInStorage;
			_maxFuelInUsage = DataToInitialize.MaxFuelInUsage;
			EventManager.OnMonsterAwake += EnableMonsterMarker;
			EventManager.OnMonsterSleep += DisableMonsterMarker;
		}

		public void Update() {
			var fuelScale = Mathf.Clamp(GameParameters.Instance.FuelInStorage / _maxFuelInStorage, 0, 1);
			_fuelBar.rectTransform.sizeDelta = new Vector2(_fuelBarSize.x * fuelScale, _fuelBarSize.y);
			var usageFuelScale = Mathf.Clamp(GameParameters.Instance.FuelInUsage / _maxFuelInUsage, 0, 1);
			_usageFuelBar.rectTransform.sizeDelta = new Vector2(_usageFuelBarSize.x * usageFuelScale, _usageFuelBarSize.y);
		}

		public void EnableMonsterMarker() {
			_monsterMarker.gameObject.SetActive(true);
		}
		
		public void DisableMonsterMarker() {
			_monsterMarker.gameObject.SetActive(false);
		}
	}
}

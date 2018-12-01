using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
	public class FuelBar : MonoBehaviour {

		public InitData DataToInitialize;
		[SerializeField] private Image _fuelBar;
		[SerializeField] private Image _usageFuelBar;

		private Vector2 _fuelBarSize;
		private Vector2 _usageFuelBarSize;

		private float _maxFuelInStorage;
		private float _maxFuelInUsage;
		
		public void Start() {
			_fuelBarSize = _fuelBar.rectTransform.sizeDelta;
			_usageFuelBarSize = _usageFuelBar.rectTransform.sizeDelta;
			_maxFuelInStorage = DataToInitialize.MaxFuelInStorage;
			_maxFuelInUsage = DataToInitialize.MaxFuelInUsage;
		}

		public void Update() {
			var fuelScale = Mathf.Clamp(GameParameters.Instance.FuelInStorage / _maxFuelInStorage, 0, 1);
			_fuelBar.rectTransform.sizeDelta = new Vector2(_fuelBarSize.x, _fuelBarSize.y * fuelScale);
			var usageFuelScale = Mathf.Clamp(GameParameters.Instance.FuelInUsage / _maxFuelInUsage, 0, 1);
			_usageFuelBar.rectTransform.sizeDelta = new Vector2(_usageFuelBarSize.x, _usageFuelBarSize.y * usageFuelScale);
		}
	}
}

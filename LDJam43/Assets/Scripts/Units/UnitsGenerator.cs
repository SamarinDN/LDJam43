using System.Collections.Generic;
using UnityEngine;

namespace Units {
	public class UnitsGenerator : MonoBehaviour {

		[SerializeField] private GameObject _unitsPool;
		[SerializeField] private GameObject _pointFirst;
		[SerializeField] private GameObject _pointSecond;
		[SerializeField] private GameObject _pointTarget;
		[SerializeField] private GameObject _pointEnd;
	
		private List<MovingUnit> _units;

		private void Start() {
			var units = _unitsPool.GetComponentsInChildren<MovingUnit>();
			_units = new List<MovingUnit>(units);
		}

		public void LaunchUnit() {
			var unit = GetUnit();
			if (!unit) {
				return;
			}

			unit.transform.position = transform.position;
			unit.ClearPoint();
			var left = _pointFirst.transform.position - _pointTarget.transform.position;
			var scale = GetScale();
			left.Scale(new Vector3(scale, scale, 1f));
			unit.AddPoint(left + _pointTarget.transform.position);
			var right = _pointSecond.transform.position - _pointTarget.transform.position;
			scale = GetScale();
			right.Scale(new Vector3(scale, scale, 1f));
			unit.AddPoint(right + _pointTarget.transform.position);
			unit.AddPoint(_pointTarget.transform.position);
			unit.AddPoint(_pointEnd.transform.position);
			unit.Run(Random.Range(9.0f, 14.0f));
		}

		private MovingUnit GetUnit() {
			return _units.Find(u => u.IsMove == false);
		}

		private float GetScale() {
			return Random.Range(0.5f, 1.0f);
		}
	}
}
 
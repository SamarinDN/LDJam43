using System.Collections.Generic;
using UnityEngine;

namespace Units {
	public class UnitsGenerator : MonoBehaviour {

		[SerializeField]
		GameObject _unitsPool;
		[SerializeField]
		GameObject _unitsTemplate;
		[SerializeField]
		GameObject _pointFirst;
		[SerializeField]
		GameObject _pointSecond;
		[SerializeField]
		GameObject _pointTarget;
		[SerializeField]
		GameObject _pointEnd;

		List<MovingUnit> _units;

		void Start() {
			var units = _unitsPool.GetComponentsInChildren<MovingUnit>();
			_units = new List<MovingUnit>(units);
			// TOOD fixme
		}

		public void LaunchUnit(float duration) {
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
			unit.Run(duration);
		}

		MovingUnit GetUnit() {
			return _units.Find(u => u.gameObject.activeInHierarchy == false);
			// TODO fixme
		}

		float GetScale() {
			return Random.Range(0.5f, 1.0f);
		}
	}
}
 
using System.Collections.Generic;
using UnityEngine;

namespace Units {
	public class PathGenerator : MonoBehaviour {
		[SerializeField] private BoxCollider2D randomPathField;
		[SerializeField] private int minPoint;
		[SerializeField] private int maxPoint;
		[SerializeField] private List<BoxCollider2D> _pointPlaces;

		public List<Vector3> GetPath() {
			var ret = new List<Vector3>();
			var pointCount = Random.Range(minPoint, maxPoint);
			for (var i = 0; i < pointCount; i++) {
				ret.Add(GetPoint(randomPathField));
				
			}
			foreach (var c in _pointPlaces) {
				ret.Add(GetPoint(c));
			}
			return ret;
		}

		private Vector3 GetPoint(BoxCollider2D c) {
			var pos = (Vector2)c.transform.position + c.offset;
			var x = Random.Range(pos.x - c.size.x/2, pos.x + c.size.x/2);
			var y = Random.Range(pos.y - c.size.y/2, pos.y + c.size.y/2);
			return new Vector3(x, y, 0);
		}
	}
}
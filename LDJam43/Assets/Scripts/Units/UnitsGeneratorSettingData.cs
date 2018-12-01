using UnityEditor;
using UnityEngine;

namespace Units {
	public class UnitsGeneratorSettingData : ScriptableObject {
		public float SpawnRate;
		public float SpawnDelta;
		public float SpawnScale;
		
		public float Speed;
		public float SpeedDelta;
		public float SpeedScale;

		[MenuItem("LDJam43/UnitsGeneratorSettingData")]
		public static void CreateMyAsset() {
			ScriptableObject asset = CreateInstance<UnitsGeneratorSettingData>();

			AssetDatabase.CreateAsset(asset, "Assets/UnitsGeneratorSettingData.asset");
			AssetDatabase.SaveAssets();

			EditorUtility.FocusProjectWindow();

			Selection.activeObject = asset;
		}
	}
}
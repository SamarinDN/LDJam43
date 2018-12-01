using UnityEditor;
using UnityEngine;

public class InitData : ScriptableObject {
	public float FuelInUsage;
	public float MaxFuelInUsage;

	public float FuelInStorage;
	public float MaxFuelInStorage;
	public int   Lives;
	public float TimePerTick;
	public float MaxFuel;
	public float fuelDecrement;

	[MenuItem("LDJam43/My Scriptable Object")]
	public static void CreateMyAsset() {
		ScriptableObject asset = CreateInstance<InitData>();

		AssetDatabase.CreateAsset(asset, "Assets/InitData.asset");
		AssetDatabase.SaveAssets();

		EditorUtility.FocusProjectWindow();

		Selection.activeObject = asset;
	}
}
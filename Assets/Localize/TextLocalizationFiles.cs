#if UNITY_EDITOR
using System.IO;
using UnityEditor;
#endif
using UnityEngine;

public class TextLocalizationFiles : ScriptableObject
{
	public TextAsset[] files;

#if UNITY_EDITOR
	[MenuItem("Component/UI/Localization Asset")]
	public static void CreateLocalizationAsset()
	{
		CreateAsset<TextLocalizationFiles>();
	}

	private static void CreateAsset<T>() where T : ScriptableObject
	{
		T asset = CreateInstance<T>();

		string path = AssetDatabase.GetAssetPath(Selection.activeObject);
		if (string.IsNullOrEmpty(path))
		{
			path = "Assets";
		}
		else if (!string.IsNullOrEmpty(Path.GetExtension(path)))
		{
			path = Path.GetDirectoryName(path);
		}

		if (!path.Contains("Resources"))
		{
			string newpath = Path.Combine(path, "Resources");
			if (!Directory.Exists(newpath))
				AssetDatabase.CreateFolder(path, "Resources");
			path = newpath;
		}

		string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(Path.Combine(path, "Localization.asset"));
		if (File.Exists(assetPathAndName))
		{
			Debug.LogWarning(string.Format("An asset called Localization was already found at {0}. There can be only one.", path));
			return;
		}
		//Debug.Log("Creating asset " + assetPathAndName + " at " + path);
		AssetDatabase.CreateAsset(asset, assetPathAndName);

		AssetDatabase.SaveAssets();
		AssetDatabase.Refresh();
		EditorUtility.FocusProjectWindow();
		Selection.activeObject = asset;
	}
#endif
}


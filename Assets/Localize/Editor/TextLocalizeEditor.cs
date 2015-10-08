using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CanEditMultipleObjects]
[CustomEditor(typeof(TextLocalize), true)]
public class TextLocalizeEditor : Editor
{
	List<string> mKeys;

	void OnEnable()
	{
		TextLocalization.Init();
		mKeys = TextLocalization.Keys;
		mKeys.Sort(delegate(string left, string right) { return System.String.Compare(left, right, System.StringComparison.Ordinal); });
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		GUILayout.Space(6f);
		EditorGUIUtility.labelWidth = 80f;

		GUILayout.BeginHorizontal();
		// Key not found in the localization file -- draw it as a text field
		SerializedProperty sp = serializedObject.FindProperty("key");
		EditorGUILayout.PropertyField(sp, new GUIContent("Key"));

		string myKey = sp.stringValue;
		bool isPresent = (mKeys != null) && mKeys.Contains(myKey);
		GUI.color = isPresent ? Color.green : Color.red;
		GUILayout.BeginVertical(GUILayout.Width(22f));
		GUILayout.Space(2f);
		GUILayout.Label(isPresent ? "\u2714" : "\u2718", "TL SelectionButtonNew", GUILayout.Height(20f));
		GUILayout.EndVertical();
		GUI.color = Color.white;
		GUILayout.EndHorizontal();

		if (isPresent)
		{
			if (DrawHeader("Preview"))
			{
				GUILayout.BeginHorizontal();
				EditorGUILayout.BeginHorizontal("AS TextArea", GUILayout.MinHeight(10f));
				GUILayout.BeginVertical();
				GUILayout.Space(2f);

				string[] keys = TextLocalization.AvailableLanguages;
				string[] values = TextLocalization.GetAll(myKey);

				if (keys != null && values != null)
				{
					for (int i = 0; i < keys.Length; ++i)
					{
						GUILayout.BeginHorizontal();
						GUILayout.Label(keys[i], GUILayout.Width(70f));

						if (GUILayout.Button(values[i], "AS TextArea", GUILayout.MinWidth(80f), GUILayout.MaxWidth(Screen.width - 110f)))
						{
							(target as TextLocalize).value = values[i];
							GUIUtility.hotControl = 0;
							GUIUtility.keyboardControl = 0;
						}
						GUILayout.EndHorizontal();
					}
				}
				else
				{
					GUILayout.Label("No preview available");
				}

				GUILayout.Space(3f);
				GUILayout.EndVertical();
				EditorGUILayout.EndHorizontal();
				GUILayout.Space(3f);
				GUILayout.EndHorizontal();
				GUILayout.Space(3f);
			}
		}
		else if (mKeys != null && !string.IsNullOrEmpty(myKey))
		{
			GUILayout.BeginHorizontal();
			GUILayout.Space(80f);
			GUILayout.BeginVertical();
			GUI.backgroundColor = new Color(1f, 1f, 1f, 0.35f);

			int matches = 0;

			for (int i = 0; i < mKeys.Count; ++i)
			{
				if (mKeys[i].StartsWith(myKey, System.StringComparison.OrdinalIgnoreCase) || mKeys[i].Contains(myKey))
				{
					if (GUILayout.Button(mKeys[i] + " \u25B2", "CN CountBadge"))
					{
						sp.stringValue = mKeys[i];
						GUIUtility.hotControl = 0;
						GUIUtility.keyboardControl = 0;
					}

					if (++matches == 8)
					{
						GUILayout.Label("...and more");
						break;
					}
				}
			}
			GUI.backgroundColor = Color.white;
			GUILayout.EndVertical();
			GUILayout.Space(22f);
			GUILayout.EndHorizontal();
		}

		serializedObject.ApplyModifiedProperties();
	}

	private static bool DrawHeader(string text)
	{
		bool state = EditorPrefs.GetBool(text, true);

		if (!state) GUI.backgroundColor = new Color(0.8f, 0.8f, 0.8f);
		GUILayout.BeginHorizontal();
		GUI.changed = false;

		text = "<b><size=11>" + text + "</size></b>";
		if (state) text = "\u25BC " + text;
		else text = "\u25BA " + text;
		if (!GUILayout.Toggle(true, text, "dragtab", GUILayout.MinWidth(20f))) state = !state;

		if (GUI.changed) EditorPrefs.SetBool(text, state);

		GUILayout.EndHorizontal();
		GUI.backgroundColor = Color.white;
		if (!state) GUILayout.Space(3f);
		return state;
	}
}

using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public static class TextLocalization
{
	public static event Localize LocalizationChanged;

	private static readonly Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>();

	private static TextLocalizationFiles localizationAsset;
	private static int nbLocaFiles;

	private static int currentLanguageIndex = -1;
	
	public static string[] AvailableLanguages { get; private set; }
	public static string CurrentLanguage { get { return AvailableLanguages[currentLanguageIndex]; } }
	public static List<string> Keys { get { return new List<string>(dictionary.Keys); }}  

	public static void Init()
	{
		localizationAsset = Resources.Load<TextLocalizationFiles>("Localization");
		if (nbLocaFiles != localizationAsset.files.Length || dictionary.Count == 0)
		{
			dictionary.Clear();
			foreach (TextAsset asset in localizationAsset.files)
				Load(asset);
			nbLocaFiles = localizationAsset.files.Length;
		}
	}

	public static bool Load(TextAsset txt)
	{
		if (txt != null && LoadCSV(txt)) 
			return true;
		return false;
	}

	private static bool LoadCSV(TextAsset asset)
	{
		CSVReader reader = new CSVReader(asset);

		// The first line should contain "KEY", followed by languages.
		List<string> temp = reader.ReadCSV();

		// There must be at least two columns in a valid CSV file
		if (temp.Count < 2) return false;

		// Ensure that the first value is what we expect
		if (!string.Equals(temp[0], "KEY"))
		{
			Debug.LogWarning("Invalid localization CSV file. The first value is expected to be 'KEY', followed by language columns.\n" +
				"Instead found '" + temp[0] + "'", asset);
			return false;
		}

		if (AvailableLanguages == null)
		{
			AvailableLanguages = new string[temp.Count - 1];
			for (int i = 1; i < temp.Count; ++i)
				AvailableLanguages[i - 1] = temp[i];
		}
		else
		{
			if (AvailableLanguages.Length != temp.Count - 1)
			{
				Debug.LogError(
					string.Format("Localization file {0} does not have the correct amount of languages, expected {1} but got {2}",
						asset.name, AvailableLanguages.Length, temp.Count - 1));
				return false;
			}
		}

		// Read the entire CSV file into memory
		temp = reader.ReadCSV(); 
		while (temp != null)
		{
			string[] values = new string[temp.Count - 1];
			for (int i = 0; i < values.Length; ++i) values[i] = temp[i + 1];
			try
			{
				dictionary.Add(temp[0], values);
			}
			catch (System.Exception)
			{
				Debug.LogError(string.Format("Unable to add '{0}' to the Localization dictionary. Found the double in {1}", temp[0], asset.name));
			}

			temp = reader.ReadCSV();
		}
		return true;
	}

	/// <summary>
	/// Select the specified language from the previously loaded CSV file.
	/// </summary>

	public static bool SelectLanguage(string alanguage)
	{
		currentLanguageIndex = -1;
		for(int i = 0; i < AvailableLanguages.Length; ++i)
			if (AvailableLanguages[i] == alanguage)
			{
				currentLanguageIndex = i;
				break;
			}

		if (Application.isPlaying)
		{
			if(LocalizationChanged != null)
				LocalizationChanged();
		}

		return currentLanguageIndex >= 0;
	}

	public static string Get(string key)
	{
		string[] vals;

		if (currentLanguageIndex != -1 && dictionary.TryGetValue(key, out vals))
		{
			if (currentLanguageIndex < vals.Length)
				return vals[currentLanguageIndex];
		}

#if UNITY_EDITOR
		Debug.LogWarning("Localization key not found: '" + key + "'");
#endif
		return key;
	}

	public static string[] GetAll(string key)
	{
		string[] vals;

		if (dictionary.TryGetValue(key, out vals))
			return vals;

#if UNITY_EDITOR
		Debug.LogWarning("Localization key not found: '" + key + "'");
#endif
		return null;
	}


	public static bool Exists(string key)
	{
		return dictionary.ContainsKey(key);
	}
}

public delegate void Localize();


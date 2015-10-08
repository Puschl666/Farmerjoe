using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UI/LocalizeText")]//Add to Component menu
[RequireComponent(typeof(Text))]
public class TextLocalize : MonoBehaviour
{
	public string key;
	private Text label;

	public string value
	{
		set
		{
			if (!string.IsNullOrEmpty(value))
			{
				label.text = value;
#if UNITY_EDITOR
			UnityEditor.EditorUtility.SetDirty(label);
#endif
			}
		}
	}

	private void Awake()
	{
		TextLocalization.LocalizationChanged += OnLocalize;
		label = GetComponent<Text>();
	}

	private void Destroy()
	{
		TextLocalization.LocalizationChanged -= OnLocalize;
	}

	private void OnEnable()
	{
#if UNITY_EDITOR
	if (!Application.isPlaying) return;
#endif
		OnLocalize();
	}

	private void Start()
	{
#if UNITY_EDITOR
	if (!Application.isPlaying) return;
#endif
		OnLocalize();
	}

	public void OnLocalize()
	{
		if (string.IsNullOrEmpty(key))
			key = label.text;

		if (!string.IsNullOrEmpty(key)) value = TextLocalization.Get(key);
	}
}

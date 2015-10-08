using UnityEngine;
using System.Collections;

public class Local : MonoBehaviour {

    private void Awake()
    {
        var syslang = Application.systemLanguage;
        var isLangAvailable = false;
        TextLocalization.Init();
        foreach (var item in TextLocalization.AvailableLanguages)
        {
            if (item == syslang.ToString())
            {
                isLangAvailable = true;
                break;
            }
        }
        if (isLangAvailable)
        {
            SelectLanguage(syslang.ToString());
        }
        else
        {
            SelectLanguage("English");
        }
    }

    public void SelectLanguage(string aName)
    {
        TextLocalization.SelectLanguage(aName);
    }
}

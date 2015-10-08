using UnityEngine;
using System.Collections;

public class TogglePanelButton : MonoBehaviour
{

    public void TogglePanel(GameObject panel)
    {
        foreach (var item in GameObject.FindGameObjectsWithTag(panel.tag))
        {
            if (item.name != panel.name) {
                item.SetActive(false);
            }
        }
        panel.SetActive(!panel.activeSelf);
    }
}
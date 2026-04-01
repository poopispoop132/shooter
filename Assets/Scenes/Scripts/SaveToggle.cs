using UnityEngine;
using UnityEngine.UI;

public class ToggleSave : MonoBehaviour
{
    public Toggle toggle;
    private const string key = "MyToggle";

    void Awake()
    {
        bool saved = PlayerPrefs.GetInt(key, 0) == 1;
        toggle.isOn = saved;

        toggle.onValueChanged.AddListener(OnToggleChanged);
    }

    void OnToggleChanged(bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
        PlayerPrefs.Save();

        Debug.Log("Saved toggle: " + value);
    }
}
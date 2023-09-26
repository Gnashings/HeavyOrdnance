using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Toggle laserToggle;
    public Toggle godModeToggle;

    void Start()
    {
        SetValues();
    }

    private void SetValues()
    {
        godModeToggle.isOn = PlayerProgress.godMode;    
        laserToggle.isOn = PlayerProgress.sightsOn;
    }

    public void SettingsGodMode()
    {
        PlayerProgress.godMode = godModeToggle.isOn;
        Debug.Log("godmode " + PlayerProgress.godMode);
    }

    public void SettingsSights()
    {
        PlayerProgress.sightsOn = laserToggle.isOn;
        Debug.Log("sightsOn " + PlayerProgress.sightsOn);
    }
}

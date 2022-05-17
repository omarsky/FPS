using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class SettingsMenuScript : MonoBehaviour
{
    [SerializeField]
    AudioMixer m_audioMixer;

    [SerializeField]
    TMP_Dropdown m_resolutionsDropdown;
    Resolution[] m_resolutions;

    private void Start()
    {
        m_resolutions = Screen.resolutions;

        m_resolutionsDropdown.ClearOptions();

        int currentResolutionIndex = 0;
        List<string> resolutionsTexts = new List<string>();
        for (int i = 0; i < m_resolutions.Length; ++i)
        {
            resolutionsTexts.Add(m_resolutions[i].ToString());

            if(m_resolutions[i].height == Screen.currentResolution.height &&
                m_resolutions[i].width == Screen.currentResolution.width &&
                m_resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
            {
                currentResolutionIndex = i;
            }
        }
        m_resolutionsDropdown.AddOptions(resolutionsTexts);
        m_resolutionsDropdown.value = currentResolutionIndex;
        m_resolutionsDropdown.RefreshShownValue();
    }

    public void SetVolume(float value)
    {
        m_audioMixer.SetFloat("MasterVolume", value);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullsreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolution)
    {
        Screen.SetResolution(m_resolutions[resolution].width, m_resolutions[resolution].height, Screen.fullScreen);
    }
}

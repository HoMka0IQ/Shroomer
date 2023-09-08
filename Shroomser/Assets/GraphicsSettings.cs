using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GraphicsSettings : MonoBehaviour
{
    public TMP_Dropdown dropdownGraphicsSettings;

    public Slider fpsSlider;

    public TMP_Text maxFPSText;
    public void Start()
    {
        setGraphics(PlayerPrefs.GetInt("GraphicsValue"));
        dropdownGraphicsSettings.value = PlayerPrefs.GetInt("GraphicsValue");

        fpsSlider.value = PlayerPrefs.GetFloat("FPS_Slider");
        fpsSliderValue();
    }
    public void dropDownMenu()
    {
        setGraphics(dropdownGraphicsSettings.value);
    }

    public void setGraphics(int value)
    {
        QualitySettings.SetQualityLevel(value);
        PlayerPrefs.SetInt("GraphicsValue", value);
    }
    
    public void fpsSliderValue()
    {
        float value = fpsSlider.value * 10;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = (int)value;
        PlayerPrefs.SetFloat("FPS_Slider", fpsSlider.value);
        if (fpsSlider.value == 0)
        {
            maxFPSText.text = "MAX";
            return;
        }
        maxFPSText.text = (int)value + "";
    }
}

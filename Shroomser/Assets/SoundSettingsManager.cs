using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SoundSettingsManager : MonoBehaviour
{
    public AudioMixer allSound;

    public Slider sound;
    public TMP_Text soundText;
    public Slider nature;
    public TMP_Text natureText;
    public Slider global;
    public TMP_Text globalSoundText;

    private void Start()
    {
        sound.value = PlayerPrefs.GetFloat("sound");
        SetSoundValume();

        nature.value = PlayerPrefs.GetFloat("nature");
        SetNatureValume();

        global.value = PlayerPrefs.GetFloat("global");
        SetGlobalValume();

    }
    public void SetSoundValume()
    {
        float value = sound.value;
        allSound.SetFloat("sound", volumeChanger(value));
        PlayerPrefs.SetFloat("sound", value);
        RefreshText(value, soundText);
    }
    public void SetNatureValume()
    {
        float value = nature.value;
        allSound.SetFloat("nature", volumeChanger(value));
        PlayerPrefs.SetFloat("nature", value);
        RefreshText(value, natureText);
    }
    public void SetGlobalValume()
    {
        float value = global.value;
        allSound.SetFloat("global", volumeChanger(value));
        PlayerPrefs.SetFloat("global", value);
        RefreshText(value, globalSoundText);
    }

    public void RefreshText(float value, TMP_Text text)
    {
        float normalizedValue = (value + 5f) / 10f;
        float percentageValue = normalizedValue * 100f;
        text.text = percentageValue + "%";
    }
    public float volumeChanger(float valume)
    {
        if (valume == global.minValue)
        {
            valume = -80;
            return valume;
        }
        if (valume >= 0)
        {
            valume = valume * 4;
        }
        if (valume < 0)
        {
            valume = valume * 4;
        }


        return valume;

    }

}

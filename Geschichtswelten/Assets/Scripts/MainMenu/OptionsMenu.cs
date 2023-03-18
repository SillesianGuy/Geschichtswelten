using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private TMP_Dropdown dropdown;

    private void Start()
    {
        volumeSlider.value = GameData.Instance.CurrentVolume;
        dropdown.value = (int) GameData.Instance.CurrentLanguage;
    }

    public void SetVolume(float volume)
    {
        mixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
        GameData.Instance.CurrentVolume = volume;
    }

    public void SelectLanguage()
    {
        GameData.Instance.CurrentLanguage = dropdown.value switch
        {
            0 => GameData.Language.DE,
            1 => GameData.Language.EN,
            _ => GameData.Language.EN
        };
    }
}

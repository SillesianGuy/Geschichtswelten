using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioMixer mixer;

    private void Start()
    {
        volumeSlider.value = GameData.Instance.CurrentVolume;
    }

    public void SetVolume(float volume)
    {
        mixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
        GameData.Instance.CurrentVolume = volume;
    }
}

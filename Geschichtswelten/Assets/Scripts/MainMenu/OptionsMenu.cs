using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    private Slider volumeSlider;
    [SerializeField] private AudioMixer mixer;
    
    public void SetVolume(float volume)
    {
        mixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
        GameManagement.Instance.ChangeVolume(Mathf.Log10(volume) * 20);
    }
}

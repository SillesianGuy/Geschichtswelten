using System;
using UnityEngine;

public class MusicAwake : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    private void Awake()
    {
        audioSource.Stop();
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
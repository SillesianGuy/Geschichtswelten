using System;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject generalSwitch;
    [SerializeField] private GameObject generalSwitch2;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private GameObject ui;
    private void Start()
    {
        BookPuzzleFinish.OnGameFinished += Finished;
    }

    private void Finished()
    {
        audioSource.Pause();
        audioSource.clip = audioClip;
        audioSource.Play();
        generalSwitch.SetActive(false);
        generalSwitch2.SetActive(true);
        ui.SetActive(false);
        BookPuzzleFinish.OnGameFinished -= Finished;
    }
}
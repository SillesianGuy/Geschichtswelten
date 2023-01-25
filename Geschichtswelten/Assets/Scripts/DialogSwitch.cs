using System;
using UnityEngine;

public class DialogSwitch : MonoBehaviour
{
    [SerializeField] private GameObject switchObject;
    private void Awake()
    {
        DialogSystem.OnDialogEnd += Switch;
    }

    private void Switch()
    {
        switchObject.SetActive(true);
        gameObject.SetActive(false);
        DialogSystem.OnDialogEnd -= Switch;    
    }
}

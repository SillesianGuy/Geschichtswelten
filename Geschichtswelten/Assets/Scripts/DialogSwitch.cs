using System;
using UnityEngine;

public class DialogSwitch : MonoBehaviour
{
    [SerializeField] private GameObject[] switchObject;
    private void Awake()
    {
        DialogSystem.OnDialogEnd += Switch;
    }

    private void Switch()
    {
        foreach (var gameObj in switchObject)
        {
            gameObj.SetActive(true);
        }
        gameObject.SetActive(false);
        DialogSystem.OnDialogEnd -= Switch;    
    }
}

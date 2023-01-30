using System;
using UnityEngine;

public class DialogSwitch : MonoBehaviour
{
    [SerializeField] private GameObject dialogActivator;
    [SerializeField] private bool withActivator;
    [SerializeField] private GameObject[] switchObject;
    private void Awake()
    {
        DialogSystem.OnDialogEnd += Switch;
    }

    private void Switch()
    {
        if (!withActivator)
        {
            foreach (var gameObj in switchObject)
            {
                gameObj.SetActive(true);
            }
            gameObject.SetActive(false);
            DialogSystem.OnDialogEnd -= Switch;    
        }
        else
        {
            if (GameData.Instance.FinishedDialogs.Contains(dialogActivator.GetComponent<DialogActivator>().dialogID))
            {
                foreach (var gameObj in switchObject)
                {
                    gameObj.SetActive(true);
                }
                gameObject.SetActive(false);
                DialogSystem.OnDialogEnd -= Switch; 
            }
        }
         
    }
}

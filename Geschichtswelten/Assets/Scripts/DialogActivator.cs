using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DialogActivator : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject dialogBox;
    private int _dialogID = 0;

    private void Start()
    {
        _dialogID = GameData.Instance.DialogID;
        GameData.Instance.DialogID++;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(!GameData.Instance.InDialog && !GameData.Instance.FinishedDialogs.Contains(_dialogID)) {
            dialogBox.gameObject.SetActive(true);
            GameData.Instance.InDialog = true;
            GameData.Instance.FinishedDialogs.Add(_dialogID);
        }
    }
}

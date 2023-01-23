using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DialogActivator : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private string tagName = "";
    [SerializeField] private bool repeat = false;
    private int _dialogID = 0;

    private void Start()
    {
        _dialogID = GameData.Instance.DialogID;
        GameData.Instance.DialogID++;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (tagName == "")
        {
            if(!GameData.Instance.InDialog && !GameData.Instance.FinishedDialogs.Contains(_dialogID)) {
                dialogBox.gameObject.SetActive(true);
                GameData.Instance.InDialog = true;
                GameData.Instance.FinishedDialogs.Add(_dialogID);
            }else if (!GameData.Instance.InDialog && repeat)
            {
                dialogBox.gameObject.SetActive(true);
                GameData.Instance.InDialog = true;
                GameData.Instance.FinishedDialogs.Add(_dialogID);
            }
        } else if (!gameObject.CompareTag(tagName))
        {
            gameObject.tag = tagName;
        }else if (gameObject.CompareTag(tagName))
        {
            if(!GameData.Instance.InDialog && !GameData.Instance.FinishedDialogs.Contains(_dialogID)) {
                dialogBox.gameObject.SetActive(true);
                GameData.Instance.InDialog = true;
                GameData.Instance.FinishedDialogs.Add(_dialogID);
            }else if (!GameData.Instance.InDialog && repeat)
            {
                dialogBox.gameObject.SetActive(true);
                GameData.Instance.InDialog = true;
                GameData.Instance.FinishedDialogs.Add(_dialogID);
            }
        }
    }
}

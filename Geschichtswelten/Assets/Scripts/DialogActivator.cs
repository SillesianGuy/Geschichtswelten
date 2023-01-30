using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DialogActivator : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private string tagName = "";
    [SerializeField] private bool repeat = false;
    [NonSerialized] public int dialogID = 0;

    private void Start()
    {
        dialogID = GameData.Instance.DialogID;
        GameData.Instance.DialogID++;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (dialogBox.gameObject.IsDestroyed())
        {
            return;
        }
        if (tagName == "")
        {
            if(!GameData.Instance.InDialog && !GameData.Instance.FinishedDialogs.Contains(dialogID)) {
                dialogBox.gameObject.SetActive(true);
                GameData.Instance.InDialog = true;
                GameData.Instance.FinishedDialogs.Add(dialogID);
            }else if (!GameData.Instance.InDialog && repeat)
            {
                dialogBox.gameObject.SetActive(true);
                GameData.Instance.InDialog = true;
                GameData.Instance.FinishedDialogs.Add(dialogID);
            }
        } else if (!gameObject.CompareTag(tagName))
        {
            gameObject.tag = tagName;
        }else if (gameObject.CompareTag(tagName))
        {
            if(!GameData.Instance.InDialog && !GameData.Instance.FinishedDialogs.Contains(dialogID)) {
                dialogBox.gameObject.SetActive(true);
                GameData.Instance.InDialog = true;
                GameData.Instance.FinishedDialogs.Add(dialogID);
            }else if (!GameData.Instance.InDialog && repeat)
            {
                dialogBox.gameObject.SetActive(true);
                GameData.Instance.InDialog = true;
                GameData.Instance.FinishedDialogs.Add(dialogID);
            }
        }
    }
}

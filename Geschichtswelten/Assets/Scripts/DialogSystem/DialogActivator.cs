using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DialogActivator : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject[] dialogBoxes;
    [SerializeField] private bool repeat = false;
    [NonSerialized] public int dialogID = 0;

    private int _currentDialogIndex = 0;
    private GameObject _currentDialogBox;
    
    private void Start()
    {
        dialogID = GameData.Instance.GetNewDialogID();
        _currentDialogBox = dialogBoxes[0];
    }
    
    /**
     * Checks if the current dialog is destroyed and picks the next one if that's the case. Checks if the current dialog
     * has repeat enabled and repeats it accordingly or selects the next available dialog if possible.
     */
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_currentDialogBox.IsDestroyed())
        {
            if (dialogBoxes.Length == _currentDialogIndex + 1) return;
            dialogID = GameData.Instance.GetNewDialogID();
            _currentDialogIndex++;
            _currentDialogBox = dialogBoxes[_currentDialogIndex];
        }
        
        if(!GameData.Instance.InDialog && !GameData.Instance.FinishedDialogs.Contains(dialogID)) {
            _currentDialogBox.gameObject.SetActive(true);
            GameData.Instance.InDialog = true;
            GameData.Instance.FinishedDialogs.Add(dialogID);
            
            if (dialogBoxes.Length != _currentDialogIndex + 1) {
                dialogID = GameData.Instance.GetNewDialogID();
                _currentDialogIndex++;
                _currentDialogBox = dialogBoxes[_currentDialogIndex];
            }
        }else if (!GameData.Instance.InDialog && repeat)
        {
            _currentDialogBox.gameObject.SetActive(true);
            GameData.Instance.InDialog = true;
            GameData.Instance.FinishedDialogs.Add(dialogID);
        }
    }
}

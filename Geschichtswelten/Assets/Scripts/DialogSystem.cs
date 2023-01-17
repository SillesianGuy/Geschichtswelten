using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DialogSystem : MonoBehaviour, IPointerClickHandler
{
    
    [SerializeField] private String path;
    [SerializeField] private TextMeshProUGUI dialogName;
    [SerializeField] private TextMeshProUGUI dialogBox;
    private int _counter = 1;
    private string[] _singleLine;
    private string[] _dialogText;
    private string[] _names;
    
    private void Awake()
    {
        string dialog = System.IO.File.ReadAllText(path);
        _singleLine = dialog.Split("\n");
        _dialogText = new string[_singleLine.Length];
        _names = new string[_singleLine.Length];
        
        for(int i = 0; i < _singleLine.Length; i++)
        {
            // TODO: für custom name zum ersetzen
            //_names[i] = _dialogTexts[i].Split(' ')[0] == "placeholder" ? "neuer name" :  _dialogTexts[i].Split(' ')[0];
            
            string[] words = _singleLine[i].Split(' ');
            
            _names[i] = words[0];
            
            for (int word = 1; word < words.Length; word++)
            {
                _dialogText[i] += word == words.Length -1 ? words[word] : words[word] + " ";
            }
        }

        dialogName.text = _names[0];
        dialogBox.text = _dialogText[0];
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (gameObject.activeSelf)
        {
            dialogName.text = _names[_counter];
            dialogBox.text = _dialogText[_counter];
            
            _counter++;
            if (_counter == _dialogText.Length)
            {
                gameObject.SetActive(false);
                _counter = 1;
                dialogName.text = _names[0];
                dialogBox.text = _dialogText[0];
                GameData.Instance.InDialog = false;
            }
        }
    }
}

using System;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Windows;
using File = System.IO.File;

public class DialogSystem : MonoBehaviour, IPointerClickHandler
{
    
    [SerializeField] private TextAsset text;
    [SerializeField] private TextAsset[] dialogLanguages;
    [SerializeField] private TextMeshProUGUI dialogName;
    [SerializeField] private TextMeshProUGUI dialogBox;
    [SerializeField] private bool moods;
    [SerializeField] private GameObject[] moodPictures;
    
    private int _counter = 1;
    private string[] _singleLine;
    private string[] _dialogText;
    private string[] _names;
    private GameObject[] _selectedMoodPictures;
    
    public delegate void DialogEnd();
    public static event DialogEnd OnDialogEnd;
    
    private void Awake()
    {
        SelectLanguage();
        ActivateDialog();
    }

    /**
     * Selects the correct dialog according to the selected language.
     */
    void SelectLanguage()
    {
        switch (GameData.Instance.CurrentLanguage)
        {
            case GameData.Language.DE:
                text = dialogLanguages[0];
                break;
            case GameData.Language.EN:
                text = dialogLanguages[1];
                break;
            default:
                text = dialogLanguages[0];
                break;
        }
    }
    
    /**
     * As soon as the dialog box got activated by the DialogActivator.cs it checks if it includes mood pictures and
     * displays the first line, name and mood picture of the dialog accordingly.
     */
    private void ActivateDialog()
    {
        if (moods)
        {
            string dialog = text.text;
            dialog = dialog.Replace("%placeholder%", GameData.Instance.Name);
            _singleLine = dialog.Split("\n");
            _dialogText = new string[_singleLine.Length];
            _names = new string[_singleLine.Length];
            _selectedMoodPictures = new GameObject[_singleLine.Length];
        
            CalculateMoodPicturesDialogText();

            dialogName.text = _names[0];
            dialogBox.text = _dialogText[0];

            _selectedMoodPictures[0].SetActive(true);
        }
        else
        {
            string dialog = text.text;
            dialog = dialog.Replace("%placeholder%", GameData.Instance.Name);
            _singleLine = dialog.Split("\n");
            _dialogText = new string[_singleLine.Length];
            _names = new string[_singleLine.Length];

            CalculateDialogText();

            dialogName.text = _names[0];
            dialogBox.text = _dialogText[0];
        }
    }

    /**
     * Reads the order of the given mood pictures and saves them in _selectedMoodPictures array.
     * Also filters and saves the dialog text into _dialogText to be able to display the text correctly.
     * Sets the correct name for the current line
     */
    private void CalculateMoodPicturesDialogText()
    {
        for(int i = 0; i < _singleLine.Length; i++)
        {
            string line = _singleLine[i];
            string[] words = _singleLine[i].Split(' ');

            if (Int32.TryParse(words[0], out var image))
            {
                _names[i] = GetName(line);
                line = line.Replace("%", "");
                _dialogText[i] = line.Substring(line.IndexOf(_names[i], StringComparison.Ordinal) + _names[i].Length + 1);
                
                _selectedMoodPictures[i] = moodPictures[image];
            }
            else
            {
                _names[i] = GetName(line);
                
                line = line.Replace("%", "");
                _dialogText[i] = line.Substring(line.IndexOf(_names[i], StringComparison.Ordinal) + _names[i].Length + 1);
            
                _selectedMoodPictures[i] = i == 0 ? _selectedMoodPictures[0] : _selectedMoodPictures[i - 1];
            }
        }
        
        foreach (var moodPicture in moodPictures)
        {
            moodPicture.SetActive(false);
        }
    }

    /**
     * Filters and saves the dialog text into _dialogText to be able to display the text correctly.
     * Sets the correct name for the current line
     */
    private void CalculateDialogText()
    {
        for(int i = 0; i < _singleLine.Length; i++)
        {
            string line = _singleLine[i];
            
            _names[i] = GetName(line);

            line = line.Replace("%", "");
            _dialogText[i] = line.Substring(line.IndexOf(_names[i], StringComparison.Ordinal) + _names[i].Length + 1);
        }
    }

    /**
     * Returns the name included in a string. The name format is '%name%' and it has to be the first word in the text
     * starting with a '%'.
     */
    private string GetName(string text)
    {
        string[] split = text.Split('%');
        
        return split[1];
    }
    
    /**
     * The event is always triggered as soon as the player clicks on any position of the dialog box.
     * It checks if the dialog is finished and disables any mood pictures as well as the dialog box and sets the GameData
     * InDialog bool to false. It also fires the OnDialogEnd event.
     * If the dialog isn't finished the new mood picture, name and text is displayed and the dialog _counter gets
     * incremented.
     */
    public void OnPointerClick(PointerEventData eventData)
    {
        if (gameObject.activeSelf)
        {
            if (_counter == _dialogText.Length)
            {
                if(moods) {
                    foreach (var moodPicture in moodPictures)
                    {
                        moodPicture.SetActive(false);
                    }
                }
                _counter = 1;
                dialogName.text = _names[0];
                dialogBox.text = _dialogText[0];
                GameData.Instance.InDialog = false;
                OnDialogEnd?.Invoke();
                gameObject.SetActive(false);
                return;
            }
            
            if(moods) {
                foreach (var moodPicture in moodPictures)
                {
                    moodPicture.SetActive(false);
                }
                
                _selectedMoodPictures[_counter].SetActive(true);
            }
            
            dialogName.text = _names[_counter];
            dialogBox.text = _dialogText[_counter];
            
            _counter++;
        }
    }
}

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
        if (moods)
        {
            string dialog = text.text;
            dialog = dialog.Replace("%placeholder%", GameData.Instance.Name);
            _singleLine = dialog.Split("\n");
            _dialogText = new string[_singleLine.Length];
            _names = new string[_singleLine.Length];
            _selectedMoodPictures = new GameObject[_singleLine.Length];
        
            calculateMoodpicturesDialogtext();

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
        
            for(int i = 0; i < _singleLine.Length; i++)
            {
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
    }

    /*
     * Reads the order of the given mood pictures and saves them in _selectedMoodPictures array.
     * Also filters and saves the dialog text into _dialogText to be able to display the text correctly.
     * TODO: Support Character names with multiple words like: %General Edward%
     */
    private void calculateMoodpicturesDialogtext()
    {
        for(int i = 0; i < _singleLine.Length; i++)
        {
            string[] words = _singleLine[i].Split(' ');
            int image;
                
            if (Int32.TryParse(words[0], out image))
            {
                _names[i] = words[1];
                
                for (int word = 2; word < words.Length; word++)
                {
                    _dialogText[i] += word == words.Length - 1 ? words[word] : words[word] + " ";
                }
                _selectedMoodPictures[i] = moodPictures[image];
            }
            else
            {
                _names[i] = words[0];
                
                for (int word = 1; word < words.Length; word++)
                {
                    _dialogText[i] += word == words.Length - 1 ? words[word] : words[word] + " ";
                }
                
                _selectedMoodPictures[i] = i == 0 ? _selectedMoodPictures[0] : _selectedMoodPictures[i - 1];
            }
        }
        
        foreach (var moodPicture in moodPictures)
        {
            moodPicture.SetActive(false);
        }
    }
    
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

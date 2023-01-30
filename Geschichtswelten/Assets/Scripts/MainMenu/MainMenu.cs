using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI inputField;
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeName()
    {
        GameData.Instance.Name = inputField.text;
    }

}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CodeInput : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textField;
    [SerializeField] private string code;
    [SerializeField] private GameObject closedBox;
    [SerializeField] private GameObject openBox;
    [SerializeField] private GameObject codeButton;
    private string _currentCode = "";
    private bool _correct = false;

    public void Submit()
    {
        if (code == _currentCode)
        {
            textField.color = Color.green;
            _correct = true;
            closedBox.SetActive(false);
            codeButton.SetActive(false);
            openBox.SetActive(true);
        }
        else
        {
            _currentCode = "";
            textField.text = "";
            _correct = false;
        }
    }
    
    public void Close()
    {
        gameObject.SetActive(false);
    }
    
    public void One()
    {
        if(!_correct) 
        {
            _currentCode += "1";
            textField.text = _currentCode;
        }
    }
    
    public void Two()
    {
        if (!_correct)
        {
            _currentCode += "2";
            textField.text = _currentCode;
        }
    }
    
    public void Three()
    {
        if (!_correct)
        {
            _currentCode += "3";
            textField.text = _currentCode;
        }
    }
    
    public void Four()
    {
        if (!_correct)
        {
            _currentCode += "4";
            textField.text = _currentCode;
        }
    }
    
    public void Five()
    {
        if (!_correct)
        {
            _currentCode += "5";
            textField.text = _currentCode;
        }
    }
    
    public void Six()
    {
        if (!_correct)
        {
            _currentCode += "6";
            textField.text = _currentCode;
        }
    }
    
    public void Seven()
    {
        if (!_correct)
        {
            _currentCode += "7";
            textField.text = _currentCode;
        }
    }
    
    public void Eight()
    {
        if (!_correct)
        {
            _currentCode += "8";
            textField.text = _currentCode;
        }
    }
    
    public void Nine()
    {
        if (!_correct)
        {
            _currentCode += "9";
            textField.text = _currentCode;
        }
    }
    
    public void Zero()
    {
        if (!_correct)
        {
            _currentCode += "0";
            textField.text = _currentCode;
        }
    }
}

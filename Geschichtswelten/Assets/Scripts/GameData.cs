using System.Collections.Generic;

public class GameData
{
    private static GameData _instance;
    private bool _inDialog = false;
    private string _name = "%Riven%";
    private int _dialogID = 0;
    private List<int> _finishedDialogs = new List<int>();
    private List<Item> _items = new List<Item>();
    private float _currentVolume = 1f;
    private Language _currentLanguage = Language.EN;

    private GameData()
    {
        if (_instance != null)
            return;
        _instance = this;
    }
    
    public static GameData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameData();
            }
            return _instance;
        }
    }
    
    public enum Language
    {
        DE,
        EN
    }
    
    public bool InDialog
    {
        get => _inDialog;
        set => _inDialog = value;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }
    
    public int DialogID
    {
        get => _dialogID;
        set => _dialogID = value;
    }
    
    public List<int> FinishedDialogs
    {
        get => _finishedDialogs;
        set => _finishedDialogs = value;
    }

    public List<Item> Items
    {
        get => _items;
        set => _items = value;
    }

    public float CurrentVolume
    {
        get => _currentVolume;
        set => _currentVolume = value;
    }

    public Language CurrentLanguage
    {
        get => _currentLanguage;
        set => _currentLanguage = value;
    }
}
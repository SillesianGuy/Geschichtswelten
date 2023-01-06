public class GameData
{
    private static GameData _instance;
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

    private bool _inDialog = false;
    
    public bool InDialog
    {
        get => _inDialog;
        set => _inDialog = value;
    }

}
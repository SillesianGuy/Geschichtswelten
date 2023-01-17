using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChange : MonoBehaviour
{
    public Texture2D cursorTexture;
    public Texture2D cursorOnButton;
    
    void Start()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void CursorOnButtonEnter()
    {
        Cursor.SetCursor(cursorOnButton, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void CursorOnButtonExit()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    public Texture2D cursorNormal;
    public Texture2D cursorInteract;
    public Texture2D cursorMove;
    public Texture2D cursorMoveLeft;
    public Texture2D cursorMoveRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoNormal()
    {
        Cursor.SetCursor(cursorNormal, Vector2.zero, CursorMode.Auto);
    }
    
    public void GoInteract()
    {
        Cursor.SetCursor(cursorInteract, Vector2.zero, CursorMode.Auto);
    }
    
    public void GoMove()
    {
        Cursor.SetCursor(cursorMove, Vector2.zero, CursorMode.Auto);
    }
    
    public void GoChangeScene(bool isLeft)
    {
        Cursor.SetCursor(isLeft?cursorMoveLeft:cursorMoveRight, Vector2.zero, CursorMode.Auto);
    }
}

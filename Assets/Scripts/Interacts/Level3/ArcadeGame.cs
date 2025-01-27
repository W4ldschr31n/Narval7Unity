using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeGame : Interactable
{
    public bool isActivable;
    

    public override void Interact()
    {
        if (isActivable)
        {
            
        }
    }

    public override void ChangeCursor()
    {
        if(isActivable)
            FindObjectOfType<CursorChanger>().GoInteract();
        else
            FindObjectOfType<CursorChanger>().GoMove();
    }
}

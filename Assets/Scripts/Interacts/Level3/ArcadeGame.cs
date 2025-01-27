using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArcadeGame : Interactable
{
    public bool isActivable;
    

    public override void Interact()
    {
        if (isActivable)
        {
            SceneManager.LoadScene("testgame", LoadSceneMode.Additive);
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

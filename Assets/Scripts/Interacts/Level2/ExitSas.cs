using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSas : Interactable
{
    public bool isUnlocked;

    public string sceneToLoad;

    public int indexToLoadIn;

    public override void Interact()
    {
        if (isUnlocked)
        {
            FindObjectOfType<SceneChanger>().LoadScene(sceneToLoad, indexToLoadIn);
        }
    }

    public override void ChangeCursor()
    {
        if(isUnlocked)
            FindObjectOfType<CursorChanger>().GoChangeScene(false);
    }
}

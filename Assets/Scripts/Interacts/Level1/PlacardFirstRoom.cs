using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacardFirstRoom : Interactable
{
    public GameObject locker;
    

    public override void Interact()
    {
        locker.SetActive(true);
        FindObjectOfType<DialogueManager>().DisplaySimpleMessage("Un morceau de journal");
    }

    public override void ChangeCursor()
    {
        FindObjectOfType<CursorChanger>().GoInteract();
    }
}

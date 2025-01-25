using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLog : Interactable
{
    public override void Interact()
    {
        Debug.Log("Pick Up Log");
    }
}

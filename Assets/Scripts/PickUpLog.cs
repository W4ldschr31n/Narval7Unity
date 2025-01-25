using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLog : Interactable
{
    public int nbNote;
    Journal GM;


    private void Start()
    {
        GM = FindObjectOfType<Journal>();

    }
    public override void Interact()
    {
        GM.AddToJournal(nbNote);
        Debug.Log("Recup journal: "+ nbNote);   
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Journal : MonoBehaviour
{
    public bool journalOpen;
    public GameObject journal;
    public GameObject Pages;

    private void Start()
    {
        journal.SetActive(journalOpen);
        
    }

    public void JournalButtun()
    {
        journalOpen = !journalOpen;
        journal.SetActive(journalOpen);
    }
    public void AddToJournal(int note)
    {
        for (int p = 0; p < Pages.transform.childCount; p++)
        {
            if (note == p)
            {

            }
        }
    }
}

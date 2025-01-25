using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Journal : MonoBehaviour
{
    public bool journalOpen;
    public GameObject journal;


    private void Start()
    {
        journal.SetActive(journalOpen);
    }

    public void JournalButtun()
    {
        journalOpen = !journalOpen;
        journal.SetActive(journalOpen);
    }
}

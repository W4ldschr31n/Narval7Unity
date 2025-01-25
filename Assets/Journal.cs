using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour
{
    bool journalOpen;
    public GameObject journal;


    public void JournalButtun()
    {
        if (!journalOpen)
        {
            journal.SetActive(true);
            journalOpen = true;
        }
        else
        {
            journal.SetActive(false);
            journalOpen = false;
        }
    }
}

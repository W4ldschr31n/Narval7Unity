using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerFirstRoom : PickUpObject
{
    public GameObject locker;
    public AudioClip lockerSound;


    public override void OnPickup()
    {
        locker.SetActive(true);
        FindObjectOfType<DialogueManager>().DisplaySimpleMessage("Banger le furby");
        FindObjectOfType<AudioRef>().PlaySFX(lockerSound);
    }
}

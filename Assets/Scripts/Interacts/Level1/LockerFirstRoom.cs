using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerFirstRoom : PickUpObject
{
    public GameObject locker;


    public override void OnPickup()
    {
        locker.SetActive(true);
        FindObjectOfType<DialogueManager>().DisplaySimpleMessage("Vous avez trouvé votre furby");
    }
}

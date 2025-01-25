using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Canvas : MonoBehaviour
{
    internal bool InventaireOpen;
    public GameObject Inventaire;

    public void InventaireButtun()
    {
        if (!InventaireOpen)
        {
            Inventaire.SetActive(true);
            InventaireOpen = true;
        }
        else
        { 
        Inventaire.SetActive(false);
        InventaireOpen = false;
        }

    }
}

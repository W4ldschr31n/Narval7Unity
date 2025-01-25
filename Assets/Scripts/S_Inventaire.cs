using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_Inventaire : MonoBehaviour
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

    public void AddToInventaire(GameObject Item)
    {
        if (Inventaire.transform.childCount < 18)
            Instantiate(Item,Inventaire.transform);
        else 
            Debug.Log("Inventaire PLein");
    }
}

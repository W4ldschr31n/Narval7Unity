using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using static UnityEditor.Progress;

public class S_Inventaire : MonoBehaviour
{
    internal bool InventaireOpen;
    public GameObject Inventaire;
    public List<ItemInBag> ItemsList;
    public GameObject prefabItem;


    private void Start()
    {
        ItemsList = new List<ItemInBag>();
    }
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

    public void AddToInventaire(SO_Item Item)
    {
        if (Inventaire.transform.childCount < 18)
        {
            ItemInBag ItemToAdd = new ItemInBag(Item.itemName, Item.sprite);
            ItemsList.Add(ItemToAdd);
            RefreshDisplay();
        }
        else
            Debug.Log("Inventaire PLein");
    }

    public void RemouvFromInventaire(string ItemName)
    {
        for (int i = 0; i < ItemsList.Count; i++)
        {
            if (ItemsList[i].Name == ItemName)
            {
                
                ItemsList.RemoveAt(i);
                RefreshDisplay();
                return;
            }
        }
    }

    public bool CheckHasItem(string ItemName)
    {
        for (int i = 0; i < ItemsList.Count; i++)
        {
            if (ItemsList[i].Name == ItemName)
            {
                return true;
            }   
        }
        return false;
    }

    public void RefreshDisplay()
    {
        foreach (Transform child in Inventaire.gameObject.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (ItemInBag Item in ItemsList)
        {
            Instantiate(prefabItem, Inventaire.transform);
        }
    }
}

public class ItemInBag
{
    public string Name;
    public Sprite Sprite;
    public  ItemInBag(string _Name, Sprite _Sprite)
    {
        Name = _Name;
        Sprite = _Sprite;
    }
}

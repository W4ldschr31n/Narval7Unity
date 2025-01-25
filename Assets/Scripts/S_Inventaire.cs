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
    public int maxSize;


    private void Start()
    {
        ItemsList = new List<ItemInBag>();
    }
    public void InventaireButton()
    {
        InventaireOpen = !InventaireOpen;
        Inventaire.SetActive(InventaireOpen);
    }

    public void AddToInventaire(SO_Item Item)
    {
        if (Inventaire.transform.childCount < maxSize)
        {
            ItemInBag ItemToAdd = new ItemInBag(Item.itemName, Item.sprite);
            ItemsList.Add(ItemToAdd);
            RefreshDisplay();
        }
        else
            Debug.Log("Inventaire Plein");
    }

    public void RemoveFromInventaire(string ItemName)
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
            var newItem =Instantiate(prefabItem, Inventaire.transform);
            newItem.GetComponent<Image>().sprite = Item.Sprite;

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

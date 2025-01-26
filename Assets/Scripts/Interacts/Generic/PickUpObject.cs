using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : Interactable
{
    S_Inventaire GM;
    public SO_Item Item;
    GestionJournal GJ;
    private void Start()
    {
        GJ = FindObjectOfType<GestionJournal>();
        GM = FindObjectOfType<S_Inventaire>();
        cursorChanger = FindObjectOfType<CursorChanger>();
    }
    public override void Interact()
    {
        if (!GM.CheckHasItem(Item.itemName))
        {
            GM.AddToInventaire(Item);
            OnPickup();
        }
        if (Item.sprite.name == "Note")
        {
            GJ.AddPages(Item.name);
        }
    }
    
    private void OnMouseEnter()
    {
        cursorChanger.GoInteract();
    }

    private void OnMouseExit()
    {
        cursorChanger.GoNormal();
    }

    public virtual void OnPickup()
    {
        return;
    }
}

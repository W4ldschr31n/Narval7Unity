using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : Interactable
{
    S_Inventaire GM;
    public SO_Item Item;
    private void Start()
    {
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

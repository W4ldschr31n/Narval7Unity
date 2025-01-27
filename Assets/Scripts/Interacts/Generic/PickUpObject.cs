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
    
    public override void ChangeCursor()
    {
        cursorChanger.GoInteract();
    }

    public virtual void OnPickup()
    {
        return;
    }
}

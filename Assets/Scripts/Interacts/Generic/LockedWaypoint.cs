using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedWaypoint : Interactable
{
    public bool isLocked;
    public bool destroysItemOnUnlock;
    public SO_Item itemNeeded;
    public S_Inventaire inventaire;
    // Start is called before the first frame update
    protected void Start()
    {
        isLocked = true;
        inventaire = FindObjectOfType<S_Inventaire>();
        cursorChanger = FindObjectOfType<CursorChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        if (isLocked)
        {
            if (inventaire.CheckHasItem(itemNeeded.name))
            {
                isLocked = false;
                if(destroysItemOnUnlock)
                    inventaire.RemoveFromInventaire(itemNeeded.name);
                UnlockWaypoint();
            }
            else
            {
                Debug.Log("An item is needed");
            }
        }
        else
        {
            InteractionWhenUnlocked();
        }
    }

    public virtual void UnlockWaypoint()
    {
        Debug.Log("Unlock waypoint");
    }

    public virtual void InteractionWhenUnlocked()
    {
        Debug.Log("Interaction unlocked");
    }

    public override void ChangeCursor()
    {
        FindObjectOfType<CursorChanger>().GoInteract();
    }
}

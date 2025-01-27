using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Waypoint : MonoBehaviour
{
    public Pathway pathway;
    public Interactable interactable;
    public Soundable soundable;

    public int index;
    // Start is called before the first frame update
    void Start()
    {
        pathway = FindObjectOfType<Pathway>();
        interactable = GetComponent<Interactable>();
        soundable = GetComponent<Soundable>();
        if (GetComponent<PickUpObject>())
        {
            GetComponent<SpriteRenderer>().sprite = GetComponent<PickUpObject>().Item.sprite;
        }
    }
           


    public void PlayerWalks()
    {
        pathway.currentCharacterPosition = index;
    }

    public void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        pathway.MoveCharacter(index);
    }

    public virtual void Interact()
    {
        if (interactable != null)
        {
            interactable.Interact();
        }
        if(soundable != null)
            soundable.Sound();
    }

    private void OnMouseEnter()
    {
        if(interactable != null)
            interactable.ChangeCursor();
        else
            FindObjectOfType<CursorChanger>().GoMove();
    }

    private void OnMouseExit()
    {
        FindObjectOfType<CursorChanger>().GoNormal();
    }
}

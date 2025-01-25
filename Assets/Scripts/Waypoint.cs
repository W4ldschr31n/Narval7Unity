using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Pathway pathway;
    public Interactable interactable;

    public int index;
    // Start is called before the first frame update
    void Start()
    {
        pathway = FindObjectOfType<Pathway>();
        interactable = GetComponent<Interactable>();
    }


    public void PlayerWalks()
    {
        pathway.currentCharacterPosition = index;
    }

    public void OnMouseDown()
    {
        pathway.MoveCharacter(index);
    }

    public virtual void Interact()
    {
        if (interactable != null)
            interactable.Interact();
    }
}

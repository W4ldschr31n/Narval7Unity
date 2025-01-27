using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : Interactable
{
    public Animator animator;

    public bool hasInteracted;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        if (!hasInteracted)
        {
            animator.Play("arcade_lightup");
            hasInteracted = true;
        }
    }

    public override void ChangeCursor()
    {
        if (!hasInteracted)
        {
            FindObjectOfType<CursorChanger>().GoInteract();
        }
        else
        {
            FindObjectOfType<CursorChanger>().GoMove();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSas : Interactable
{
    public Animator waterAnimator;
    public ExitSas exitSas;

    public bool isUsed;
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
        if (!isUsed)
        {
            waterAnimator.Play("water");
            exitSas.isUnlocked = true;
            FindObjectOfType<Respiration>().IsInWather = true;
        }
    }

    private void OnMouseEnter()
    {
        if(!isUsed)
            FindObjectOfType<CursorChanger>().GoInteract();
        else
            FindObjectOfType<CursorChanger>().GoMove();
    }

    private void OnMouseExit()
    {
        FindObjectOfType<CursorChanger>().GoNormal();
    }
}

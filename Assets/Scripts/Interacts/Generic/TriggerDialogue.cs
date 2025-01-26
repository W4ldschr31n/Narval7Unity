using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : Interactable
{
    public Dialogue dialogue;
    public DialogueManager dialogueManager;
    public bool hasTriggered;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        cursorChanger = FindObjectOfType<CursorChanger>();
    }

    public override void Interact()
    {
        if (!hasTriggered)
        {
            dialogueManager.StartDialogue(dialogue);
            hasTriggered = true;
        }
    }

    private void OnMouseEnter()
    {
        if(!hasTriggered)
            cursorChanger.GoInteract();
    }

    private void OnMouseExit()
    {
        cursorChanger.GoNormal();
    }
}

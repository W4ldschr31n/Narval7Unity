using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerDialogue : Interactable
{
    public Dialogue dialogue;
    public DialogueManager dialogueManager;
    public CharacterMovement characterMovement;
    public bool hasTriggered;
    public UnityEvent onDialogueEndEvent;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        cursorChanger = FindObjectOfType<CursorChanger>();
        characterMovement = FindObjectOfType<CharacterMovement>();
        onDialogueEndEvent = new UnityEvent();
        onDialogueEndEvent.AddListener(OnDialogueEnd);
    }

    public override void Interact()
    {
        if (!hasTriggered)
        {
            dialogueManager.StartDialogue(dialogue, onDialogueEndEvent);
            hasTriggered = true;
        }
    }

    public override void ChangeCursor()
    {
        if(!hasTriggered)
            cursorChanger.GoListen();
        else
            cursorChanger.GoMove();
    }



    public virtual void OnDialogueEnd()
    {
        return;
    }
}

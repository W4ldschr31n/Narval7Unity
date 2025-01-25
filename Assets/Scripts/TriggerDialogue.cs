using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : Interactable
{
    public Dialogue dialogue;
    public DialogueManager dialogueManager;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    public override void Interact()
    {
        dialogueManager.StartDialogue(dialogue);
    }
}

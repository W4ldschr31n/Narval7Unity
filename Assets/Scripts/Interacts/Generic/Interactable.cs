using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected CursorChanger cursorChanger;
    public abstract void Interact();
}

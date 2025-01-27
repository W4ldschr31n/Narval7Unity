using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonButton : MonoBehaviour
{
    public SimonGame game;
    public DanceDirection danceDirection;

    private void Start()
    {
        game = FindObjectOfType<SimonGame>();
    }

    private void OnMouseDown()
    {
        game.ClickDirection(danceDirection);
    }
}

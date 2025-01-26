using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamberDoor : LockedWaypoint
{
    public GameObject _light;
    public SceneChanger sceneChanger;
    public string nextScene;
    public int indexInScene;
    new void Start()
    {
        base.Start();
        Debug.Log("Deuxieme");
        sceneChanger = FindObjectOfType<SceneChanger>();
    }
    public override void UnlockWaypoint()
    {
        _light.SetActive(true);
    }

    public override void InteractionWhenUnlocked()
    {
        sceneChanger.LoadScene(nextScene, indexInScene);
    }

    private void OnMouseEnter()
    {
        if(isLocked)
            cursorChanger.GoInteract();
        else
            cursorChanger.GoMove(false);
    }

    private void OnMouseExit()
    {
        cursorChanger.GoNormal();
    }
}

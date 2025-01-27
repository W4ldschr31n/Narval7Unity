using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamberDoor : LockedWaypoint
{
    public GameObject _light;
    public GameObject door;
    public SceneChanger sceneChanger;
    public string nextScene;
    public int indexInScene;
    public AudioClip doorSound;
    
    new void Start()
    {
        base.Start();
        sceneChanger = FindObjectOfType<SceneChanger>();
    }
    public override void UnlockWaypoint()
    {
        _light.SetActive(true);
        door.SetActive(false);
        FindObjectOfType<AudioRef>().PlaySFX(doorSound);
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
            cursorChanger.GoChangeScene(false);
    }

    private void OnMouseExit()
    {
        cursorChanger.GoNormal();
    }
}

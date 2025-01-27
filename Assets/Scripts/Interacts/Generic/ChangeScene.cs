using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : Interactable
{
    public string sceneToLoad;
    public int indexToSpawnIn;
    private SceneChanger sceneChanger;
    public bool isLeft;

    private void Start()
    {
        sceneChanger = FindObjectOfType<SceneChanger>();
        cursorChanger = FindObjectOfType<CursorChanger>();
    }

    public override void Interact()
    {
        sceneChanger.LoadScene(sceneToLoad, indexToSpawnIn);
    }

    public override void ChangeCursor()
    {
        cursorChanger.GoChangeScene(isLeft);
    }
}

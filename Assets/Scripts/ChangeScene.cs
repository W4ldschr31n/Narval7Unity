using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : Interactable
{
    public string sceneToLoad;
    public int indexToSpawnIn;
    private SceneChanger sceneChanger;

    private void Start()
    {
        sceneChanger = FindObjectOfType<SceneChanger>();
    }

    public override void Interact()
    {
        Debug.Log("ChangeScene");
        sceneChanger.LoadScene(sceneToLoad, indexToSpawnIn);
    }
}

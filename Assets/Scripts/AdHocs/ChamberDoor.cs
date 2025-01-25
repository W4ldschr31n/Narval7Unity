using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamberDoor : LockedWaypoint
{
    public GameObject light;
    public SceneChanger sceneChanger;
    public string nextScene;
    public int indexInScene;
    void Start()
    {
        base.Start();
        Debug.Log("Deuxieme");
        sceneChanger = FindObjectOfType<SceneChanger>();
    }
    public override void UnlockWaypoint()
    {
        light.SetActive(true);
    }

    public override void InteractionWhenUnlocked()
    {
        sceneChanger.LoadScene(nextScene, indexInScene);
    }
}

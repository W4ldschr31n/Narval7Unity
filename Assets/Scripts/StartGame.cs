using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string firstScene;
    private void Start()
    {
        SceneManager.LoadScene(firstScene);
    }
}

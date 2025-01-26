using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Respiration : MonoBehaviour
{
    [Header("Jauge")]
    public Image jauge;
    public float maxRespiration = 100.0f;
    public float decayRate = 1.0f;

    internal bool IsInWather = false;
    float currentRespiration;


    [Header ("Respawn")]
    SceneChanger sceneChanger;



    void Start()
    {
        sceneChanger = FindObjectOfType<SceneChanger>();
        currentRespiration = maxRespiration;
    }

    private void Update()
    {
        if (IsInWather)
        {   
            currentRespiration -= Time.deltaTime * decayRate;
            jauge.fillAmount = currentRespiration / maxRespiration;
        }
        if (currentRespiration <= 0)
        {
            sceneChanger.LoadScene(SceneManager.GetActiveScene().name, sceneChanger.indexToLoadIn);
            currentRespiration = maxRespiration;
            IsInWather=false;
        }
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Respiration : MonoBehaviour
{
    public GameObject jauge; 
    [Header("ProgressBar")]
    public Image progressBar;
    public Image bubble;
    public float maxRespiration = 100.0f;
    public float decayRate = 1.0f;
    public bool IsInWather;
    float currentRespiration;
    
    SceneChanger sceneChanger;

    void Start()
    {
        sceneChanger = FindObjectOfType<SceneChanger>();
        currentRespiration = maxRespiration;
        Deactivate();
    }

    public void Activate()
    {
        IsInWather = true;
        jauge.SetActive(true);
        currentRespiration = maxRespiration;
    }

    public void Deactivate()
    {
        IsInWather = false;
        jauge.SetActive(false);
    }

    private void Update()
    {
        if (IsInWather)
        {   
            currentRespiration -= Time.deltaTime * decayRate;
            progressBar.fillAmount = currentRespiration / maxRespiration;
            bubble.transform.localPosition = Vector3.Lerp(new Vector3(-460, -24, 0), new Vector3(390, -24, 0), currentRespiration / maxRespiration);
        }
        if (currentRespiration <= 0)
        {
            sceneChanger.LoadScene(SceneManager.GetActiveScene().name, sceneChanger.indexToLoadIn);
            currentRespiration = maxRespiration;
        }
    }

}

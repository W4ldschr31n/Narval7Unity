using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respiration : MonoBehaviour
{
    public Image jauge;
    public float maxRespiration = 100.0f;
    public float currentRespiration;
    public float decayRate = 1.0f;
    public bool IsInWather = false;

    void Start()
    {
        currentRespiration = maxRespiration;
    }

    private void Update()
    {
        if (IsInWather)
        {   
            currentRespiration -= Time.deltaTime * decayRate;
            jauge.fillAmount = currentRespiration / maxRespiration;
        }
    }

}

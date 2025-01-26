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

    internal bool IsInWather = true;
    float currentRespiration;


    [Header ("Respawn")]
    public string RespawnSceneToLoad;

    [Header("Vignette")]    
    public Image vignetteImage;     
    public float fadeInDuration = 0.5f;


    private void Awake()
    {
        vignetteImage.gameObject.SetActive(true);
    }

    void Start()
    {
        currentRespiration = maxRespiration;
        StartCoroutine(DeTransitionCoroutine());
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
            StartCoroutine(TransitionCoroutine());
        }


    }

    private IEnumerator TransitionCoroutine()
    {
        vignetteImage.gameObject.SetActive(true);

        float t = 0f;
        Color startColor = vignetteImage.color;
        startColor.a = 0f;
        vignetteImage.color = startColor;

        while (t < fadeInDuration)
        {
            t += Time.deltaTime;
            vignetteImage.color = new Color(0, 0, 0, Mathf.Lerp(0, 1, t / fadeInDuration));
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(RespawnSceneToLoad);
    }
    public IEnumerator DeTransitionCoroutine()
    {
        float t = 0f;
        Color startColor = vignetteImage.color;

        while (t < fadeInDuration)
        {
            t += Time.deltaTime;
            vignetteImage.color = new Color(0, 0, 0, Mathf.Lerp(1, 0, t / fadeInDuration));
            yield return null;
        }

        vignetteImage.gameObject.SetActive(false);
    }

}

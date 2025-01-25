using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public FadeScreen fadeScreen;
    public int indexToLoadIn;
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        fadeScreen = FindObjectOfType<FadeScreen>();
    }


    public void LoadScene(string sceneName, int _indexToLoadIn=0)
    {
        indexToLoadIn = _indexToLoadIn;
        StartCoroutine(LoadSceneCo(sceneName));
    }
    
    
    IEnumerator LoadSceneCo(string sceneName)
    {
        // Fade to black and load the loading screen
        fadeScreen.FadeIn();
        yield return new WaitForSeconds(1f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Fade out as the new scene is loaded
        fadeScreen.FadeOut();
    }
    
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Move player if we move to another scene
        if (mode == LoadSceneMode.Single)
        {
            CharacterMovement characterMovement = FindObjectOfType<CharacterMovement>();
            Pathway pathway = FindObjectOfType<Pathway>();
            // Init scene has no data
            if(characterMovement!=null && pathway != null)
            {
                pathway.currentCharacterPosition = indexToLoadIn;
                characterMovement.transform.position = pathway.waypoints[indexToLoadIn].transform.position;
            }
        }
    }
}

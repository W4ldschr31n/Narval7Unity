using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int indexToLoadIn;
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void LoadScene(string sceneName, int _indexToLoadIn=0)
    {
        indexToLoadIn = _indexToLoadIn;
        SceneManager.LoadScene(sceneName);
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

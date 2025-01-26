using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSas : Interactable
{
    public bool isUnlocked;

    public string sceneToLoad;

    public int indexToLoadIn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        if (isUnlocked)
        {
            FindObjectOfType<SceneChanger>().LoadScene(sceneToLoad, indexToLoadIn);
        }
    }
}

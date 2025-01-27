using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArcadeGame : Interactable
{
    public bool isActivable;
    public SO_Item itemReward;
    public AudioClip audioClip;
    public GameObject simonGame;
    public GameObject enemy;

    public override void Interact()
    {
        if (isActivable)
        {
            simonGame.SetActive(true);
            simonGame.GetComponent<SimonGame>().StartGame();
            isActivable = false;
        }
    }

    public override void ChangeCursor()
    {
        if(isActivable)
            FindObjectOfType<CursorChanger>().GoInteract();
        else
            FindObjectOfType<CursorChanger>().GoMove();
    }

    public void GiveReward()
    {
        simonGame.SetActive(false);
        FindObjectOfType<DialogueManager>().DisplaySimpleMessage("Le jeu vous offre un Furby en récompense");
        FindObjectOfType<S_Inventaire>().AddToInventaire(itemReward);
        FindObjectOfType<AudioRef>().PlaySFX(audioClip);
        enemy.SetActive(true);
    }
}

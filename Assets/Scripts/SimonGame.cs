using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum DanceDirection
{
    Left,
    Right,
    Up,
    Down
}

[Serializable]
public class DanceRound
{
    public float timeBetweenHints;
    public List<DanceDirection> danceDirections = new List<DanceDirection>();
}
public class SimonGame : MonoBehaviour
{
    public GameObject buttons;
    public SpriteRenderer hint;
    public Animator gameAnimator;
    public List<DanceRound> danceRounds = new List<DanceRound>();
    public Queue<DanceRound> danceRoundsQueue;
    public bool isPlayerTurn;
    public Sprite leftSprite;
    public Sprite rightSprite;
    public Sprite upSprite;
    public Sprite downSprite;
    private Dictionary<DanceDirection, Sprite> dirToSprite;
    private Dictionary<DanceDirection, String> dirToAnim;
    private List<DanceDirection> playerInput = new List<DanceDirection>();
    private DanceRound currentRound;

    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip buttonSound;
    // Start is called before the first frame update
    public void StartGame()
    {
        dirToSprite = new Dictionary<DanceDirection, Sprite>()
        {
            { DanceDirection.Left, leftSprite },
            { DanceDirection.Right, rightSprite },
            { DanceDirection.Up, upSprite },
            { DanceDirection.Down, downSprite }
        };
        dirToAnim = new Dictionary<DanceDirection, String>()
        {
            { DanceDirection.Left, "chara_dance_left" },
            { DanceDirection.Up, "chara_dance_up" },
            { DanceDirection.Down, "chara_dance_down" },
            { DanceDirection.Right, "chara_dance_right" },
        };
        danceRoundsQueue = new Queue<DanceRound>(danceRounds);
        currentRound = danceRoundsQueue.Dequeue();
        StartCoroutine(PlayRound(currentRound));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator PlayRound(DanceRound round)
    {
        isPlayerTurn = false;
        buttons.SetActive(false);
        playerInput.Clear();
        yield return new WaitForSeconds(1.0f);
        foreach (DanceDirection dir in round.danceDirections)
        {
            hint.sprite = null;
            yield return new WaitForSeconds(0.2f);
            hint.sprite = dirToSprite[dir];
            yield return new WaitForSeconds(round.timeBetweenHints);
        }
        isPlayerTurn = true;
        buttons.SetActive(true);
        hint.sprite = null;
    }

    public void ClickDirection(DanceDirection direction)
    {
        if (!isPlayerTurn)
            return;
        gameAnimator.Play(dirToAnim[direction]);
        playerInput.Add(direction);
        if (playerInput.Count >= currentRound.danceDirections.Count)
        {
            if (playerInput.SequenceEqual(currentRound.danceDirections))
            {
                gameAnimator.Play("winSimon");
                
                if (danceRoundsQueue.Count > 0)
                {
                    FindObjectOfType<AudioRef>().PlaySFX(winSound);
                    currentRound = danceRoundsQueue.Dequeue();
                    StartCoroutine(PlayRound(currentRound));
                }
                else
                    Win();
            }
            else
            {
                gameAnimator.Play("loseSimon");
                FindObjectOfType<AudioRef>().PlaySFX(loseSound);
                StartCoroutine(PlayRound(currentRound));
            }
        }
        else
        {
            FindObjectOfType<AudioRef>().PlaySFX(buttonSound);
        }
    }

    public void Win()
    {
        FindObjectOfType<ArcadeGame>().GiveReward();
    }
}

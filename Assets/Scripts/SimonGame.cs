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
    public Animator playerAnimator;
    public Animator gameAnimator;
    public List<DanceRound> danceRounds = new List<DanceRound>();
    public Queue<DanceRound> danceRoundsQueue;
    public bool isPlayerTurn;
    public Sprite leftSprite;
    public Sprite rightSprite;
    public Sprite upSprite;
    public Sprite downSprite;
    private Dictionary<DanceDirection, Sprite> dirToSprite;
    private List<DanceDirection> playerInput = new List<DanceDirection>();
    private DanceRound currentRound;
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
        playerInput.Add(direction);
        if (playerInput.Count >= currentRound.danceDirections.Count)
        {
            if (playerInput.SequenceEqual(currentRound.danceDirections))
            {
                gameAnimator.Play("winSimon");
                Win();
                return;
                if (danceRoundsQueue.Count > 0)
                {
                    currentRound = danceRoundsQueue.Dequeue();
                    StartCoroutine(PlayRound(currentRound));
                }
                else
                    Win();
            }
            else
            {
                gameAnimator.Play("loseSimon");
                StartCoroutine(PlayRound(currentRound));
            }
        }
    }

    public void Win()
    {
        FindObjectOfType<ArcadeGame>().GiveReward();
    }
}

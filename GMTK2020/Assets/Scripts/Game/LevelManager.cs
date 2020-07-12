using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : Singleton<LevelManager>
{
    public GameObject deckPrefab;
    public GameObject handPrefab;

    public Transform deckPosiiton;
    public Transform handPosition;
    public Transform discardPosition;

    public Deck deck {get; private set;}
    public Hand hand {get; private set;}
    public Deck discard {get; private set;}

    public PlayerObject playerObject;

    protected override void Awake()
    {
        base.Awake();

        GameObject deckGO = Instantiate(deckPrefab, deckPosiiton);
        deckGO.transform.localPosition = Vector3.zero;
        deck = deckGO.GetComponent<Deck>();

        GameObject handGO = Instantiate(handPrefab, handPosition);
        handGO.transform.localPosition = Vector3.zero;
        hand = handGO.GetComponent<Hand>();

        GameObject discardGO = Instantiate(deckPrefab, discardPosition);
        discardGO.transform.localPosition = Vector3.zero;
        discard = discardGO.GetComponent<Deck>();
    }

    private void Start()
    {

    }

    public void InitializeLevel()
    {
        if(deck)
        deck.Init(GameManager.Get().currentDeck.ToArray());

        if(discard)
            discard.Init(null);

        SetLevelState(LevelState.FadeIn);
        StartCoroutine(FadeIn(1f));
    }

    IEnumerator FadeIn(float fadeTime)
    {
        yield return new WaitForSeconds(fadeTime);
        SetLevelState(LevelState.PlayerTurn);
    }

    public Action<LevelState> OnLevelStateChange;

    void SetLevelState(LevelState newLevelState)
    {
        if(levelState != newLevelState)
        {
            levelState = newLevelState;
            if(OnLevelStateChange != null)
            {
                OnLevelStateChange.Invoke(levelState);
            }

            Debug.Log("New level state: " + newLevelState.ToString());
        }
    }

    public LevelState levelState {get; private set;}

    public void EndPlayerTurn()
    {
        if(levelState == LevelState.PlayerTurn)
        {
            SetLevelState(LevelState.EnemyTurn);
        }
    }

    public void EndEnemyTurn()
    {
        if (levelState == LevelState.EnemyTurn)
        {
            SetLevelState(LevelState.PlayerTurn);
        }
    }

    public void OnPlayerMoveToDoor()
    {
        SetLevelState(LevelState.FadeOut);
        StartCoroutine(FadeOut(1f));
    }

    IEnumerator FadeOut(float FadeTime)
    {
        yield return new WaitForSeconds(FadeTime);
        GameManager.Get().LevelComplete();
    }

    public void ShuffleDiscardIntoDeck()
    {
        deck.AddAndShuffle(discard);
    }
}

public enum LevelState
{
    FadeIn = 0,
    PlayerTurn = 1,
    EnemyTurn = 2,
    FadeOut = 3
}

[System.Serializable]
public struct LevelData
{
    public int SceneIdx;
}
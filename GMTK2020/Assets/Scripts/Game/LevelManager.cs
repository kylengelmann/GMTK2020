using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : Singleton<LevelManager>
{
    public void InitializeLevel()
    {
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
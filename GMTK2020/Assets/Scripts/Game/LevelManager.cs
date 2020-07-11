using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public void InitializeLevel()
    {

    }

    public LevelState levelState {get; private set;}

    public void EndPlayerTurn()
    {
        if(levelState == LevelState.PlayerTurn)
        {
            levelState = LevelState.EnemyTurn;
        }
    }

    public void EndEnemyTurn()
    {
        if (levelState == LevelState.EnemyTurn)
        {
            levelState = LevelState.PlayerTurn;
        }
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
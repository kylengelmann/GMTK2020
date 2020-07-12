using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    List<Enemy> enemies;

    private void Awake()
    {
        enemies = new List<Enemy>();
    }

    private void Start()
    {
        LevelManager.Get().OnLevelStateChange += OnLevelStateChanged;
    }

    public void RegisterEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
    }

    void OnLevelStateChanged(LevelState levelState)
    {
        if(levelState == LevelState.EnemyTurn)
        {
            StartCoroutine(TakeEnemyTurns());
        }
    }

    IEnumerator TakeEnemyTurns()
    {
        foreach (Enemy enemy in enemies)
        {
            yield return enemy.StartTurn();
            if(ActionManager.Get().bIsProcessingQueue)
            {
                yield return null;
            }
        }

        LevelManager.Get().EndEnemyTurn();
    }
}

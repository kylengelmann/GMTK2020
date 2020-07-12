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

    public void UnregisterEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
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
            while (ActionManager.Get().bIsProcessingQueue)
            {
                yield return null;
            }
            yield return enemy.StartTurn();
        }
        while (ActionManager.Get().bIsProcessingQueue)
        {
            yield return null;
        }
        LevelManager.Get().EndEnemyTurn();
    }
}

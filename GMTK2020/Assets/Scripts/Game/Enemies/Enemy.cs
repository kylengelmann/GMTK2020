using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int sight = 2;
    public int movement = 1;
    protected EnemyObject enemyObject;

    protected virtual void Start()
    {
        enemyObject = GetComponent<EnemyObject>();
        LevelManager.Get().enemyManager.RegisterEnemy(this);
    }

    public Coroutine StartTurn()
    {
        return StartCoroutine(TakeTurn());
    }

    protected virtual IEnumerator TakeTurn()
    {
        ActionManager actionManager = ActionManager.Get();

        Vector2Int playerPos = LevelManager.Get().playerObject.GetGridCell();
        Direction[] directions;
        int playerDist = LevelGrid.Get().FindShortestPathBetween(enemyObject.GetGridCell(), playerPos, out directions);
        yield return null;
        if(playerDist <= sight && playerDist > 0)
        {
            int movesTaken = 0;
            while(movesTaken < movement && (playerDist - movesTaken) > 1)
            {
                ActionData actionData = new ActionData(){type = ActionType.Move, direction = directions[movesTaken]};
                actionManager.AddActionToQueue(actionData);
                movesTaken++;
            }
            if((playerDist - movesTaken) == 1)
            {
                ActionData actionData = new ActionData() { type = ActionType.Attack, direction = directions[movesTaken] };
                actionManager.AddActionToQueue(actionData);
            }
            actionManager.StartProcessingQueue(enemyObject);
        }
        yield return null;
    }
    
}

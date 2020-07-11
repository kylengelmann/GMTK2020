using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : Singleton<ActionManager>
{
    Queue<ActionType> ActionQueue;

    protected override void Awake()
    {
        base.Awake();

        ActionQueue = new Queue<ActionType>();
    }

    bool bIsProcessingQueue = false;

    public void AddActionToQueue(ActionType actionType)
    {
        if(!bIsProcessingQueue)
        {
            ActionQueue.Enqueue(actionType);
        }
    }

    public void StartProcessingQueue(IActionObject actionObject)
    {
        if(!bIsProcessingQueue)
        {
            StartCoroutine(ProcessActionQueue(actionObject));
        }
    }
    
    IEnumerator ProcessActionQueue(IActionObject actionObject)
    {
        bIsProcessingQueue = true;

        ActionType currentAction;
        while(ActionQueue.Count > 0)
        {
            currentAction = ActionQueue.Dequeue();
            switch(currentAction)
            {
                case ActionType.MoveUp:
                    yield return actionObject.StartMove(Direction.North);
                    break;
                case ActionType.MoveDown:
                    yield return actionObject.StartMove(Direction.South);
                    break;
                case ActionType.MoveLeft:
                    yield return actionObject.StartMove(Direction.West);
                    break;
                case ActionType.MoveRight:
                    yield return actionObject.StartMove(Direction.East);
                    break;
                case ActionType.Attack:
                    yield return actionObject.StartAttack();
                    break;
            }
        }

        bIsProcessingQueue = false;
    }

}

public enum ActionType
{
    MoveUp = 0,
    MoveDown = 1,
    MoveLeft = 2,
    MoveRight = 4,
    Attack = 5,
}
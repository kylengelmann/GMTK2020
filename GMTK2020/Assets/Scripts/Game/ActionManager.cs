using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : Singleton<ActionManager>
{
    Queue<ActionData> ActionQueue;

    protected override void Awake()
    {
        base.Awake();

        ActionQueue = new Queue<ActionData>();
        bIsProcessingQueue = false;
    }

    public bool bIsProcessingQueue {get; private set;}

    public void AddActionToQueue(ActionData actionData)
    {
        ActionQueue.Enqueue(actionData);
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

        ActionData currentAction;
        while(ActionQueue.Count > 0)
        {
            currentAction = ActionQueue.Dequeue();
            switch(currentAction.type)
            {
                case ActionType.Move:
                    yield return actionObject.StartMove(currentAction.direction);
                    break;
                case ActionType.Attack:
                    yield return actionObject.StartAttack();
                    break;
                case ActionType.Defend:
                    yield return actionObject.StartDefend();
                    break;
            }
        }

        bIsProcessingQueue = false;
    }

}

public enum ActionType
{
    Move = 0,
    Attack = 1,
    Defend = 2,
}

public struct ActionData
{
    public ActionType type;
    public Direction direction;
}
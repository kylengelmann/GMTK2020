using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : LevelObject, IActionObject
{
    public override ObjectType GetObjectType() { return ObjectType.Player; }

    [SerializeField] float moveTime = .5f;
    public AnimationCurve MoveCurve;
    public AnimationCurve BounceCurve;

    protected override void Start()
    {
        base.Start();

        LevelManager.Get().playerObject = this;
    }

    public Coroutine StartMove(Direction direction)
    {
        return StartCoroutine(PerformMove(direction));
    }

    IEnumerator PerformMove(Direction direction)
    {
        bool bCanMove = currentGrid.CanMoveDirection(GetGridCell(), direction);
        Vector3 startPosition = transform.position;
        float currentMoveTime = 0f;
        while(currentMoveTime < moveTime)
        {
            float totalMove = bCanMove ? MoveCurve.Evaluate(currentMoveTime / moveTime) : BounceCurve.Evaluate(currentMoveTime/moveTime);
            Vector3 moveDir = Vector3.zero;
            switch(direction)
            {
                case Direction.East:
                    moveDir = Vector3.right;
                    break;
                case Direction.West:
                    moveDir = Vector3.left;
                    break;
                case Direction.North:
                    moveDir = Vector3.up;
                    break;
                case Direction.South:
                    moveDir = Vector3.down;
                    break;
            }
            transform.position = startPosition + moveDir * totalMove;
            yield return null;
            currentMoveTime += Time.deltaTime;
        }
        MoveGrid(direction);
    }

    public Coroutine StartAttack()
    {
        return StartCoroutine(PerformAttack());
    }

    IEnumerator PerformAttack()
    {
        yield return new WaitForSeconds(.5f);
    }

    public Coroutine StartDefend()
    {
        return StartCoroutine(PerformDefend());
    }

    IEnumerator PerformDefend()
    {
        yield return new WaitForSeconds(.5f);
    }
}

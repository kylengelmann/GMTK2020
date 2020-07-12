using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterObject : LevelObject, IActionObject
{
    [SerializeField] float moveTime = .5f;
    public AnimationCurve MoveCurve;
    public AnimationCurve BounceCurve;

    bool isDefending;
    Animator animaAnimator;

    protected override void Start()
    {
        base.Start();

        animaAnimator = GetComponentInChildren<Animator>();

        animaAnimator.SetInteger("dirintion", 2);
    }

    public virtual Coroutine StartMove(Direction direction)
    {

        int dirintion = (int)direction;
        animaAnimator.SetInteger("dirintion", dirintion);

        return StartCoroutine(PerformMove(direction));
    }

    protected virtual IEnumerator PerformMove(Direction direction)
    {
        bool bCanMove = currentGrid.CanMoveDirection(GetGridCell(), direction);
        Vector3 startPosition = transform.position;
        float currentMoveTime = 0f;
        while (currentMoveTime < moveTime)
        {
            float totalMove = bCanMove ? MoveCurve.Evaluate(currentMoveTime / moveTime) : BounceCurve.Evaluate(currentMoveTime / moveTime);
            Vector3 moveDir = Vector3.zero;
            switch (direction)
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

    public virtual Coroutine StartAttack(Direction direction)
    {
        animaAnimator.SetInteger("attintck", (int) direction);
        animaAnimator.ResetTrigger("actriggerion");
        animaAnimator.SetTrigger("actriggerion");
        animaAnimator.SetInteger("dirintion", (int) direction);
        return StartCoroutine(PerformAttack(direction));
    }

    protected virtual IEnumerator PerformAttack(Direction direction)
    {
        yield return new WaitForSeconds(moveTime);
    }

    public virtual Coroutine StartDefend()
    {
        return StartCoroutine(PerformDefend());
    }

    protected virtual IEnumerator PerformDefend()
    {
        yield return new WaitForSeconds(moveTime);
    }
}

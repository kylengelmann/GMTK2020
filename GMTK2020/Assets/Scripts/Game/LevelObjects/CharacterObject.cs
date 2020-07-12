using System.Collections;
using System;
using UnityEngine;

public abstract class CharacterObject : LevelObject, IActionObject, IDamageable
{
    public AudioClip[] actionClips;
    AudioSource audioSouce;

    [SerializeField] float moveTime = .5f;
    public AnimationCurve MoveCurve;
    public AnimationCurve BounceCurve;

    Animator animaAnimator;

    [SerializeField] int health = 1;

    public int GetHealth() {return health;}

    public Action OnCharacterDeath;

    bool bIsDefending = false;

    protected override void Start()
    {
        base.Start();

        animaAnimator = GetComponentInChildren<Animator>();

        animaAnimator.SetInteger("dirintion", 2);
        animaAnimator.ResetTrigger("moveTrigger");
        animaAnimator.ResetTrigger("actriggerion");

        audioSouce = GetComponent<AudioSource>();
    }

    void PlayActionSound(ActionType actionType)
    {
        int actionIdx = (int)actionType;
        if(actionIdx > 0 && actionIdx < actionClips.Length)
        {
            AudioClip actionClip = actionClips[actionIdx];
            if(actionClip && audioSouce)
            {
                audioSouce.PlayOneShot(actionClip);
            }
        }
    }

    public void StartTurn()
    {
        bIsDefending = false;
        animaAnimator.SetBool("isDefending", bIsDefending);
    }

    public virtual Coroutine StartMove(Direction direction)
    {
        PlayActionSound(ActionType.Move);

        int dirintion = (int)direction;
        animaAnimator.SetInteger("dirintion", dirintion);

        animaAnimator.ResetTrigger("moveTrigger");
        animaAnimator.SetTrigger("moveTrigger");

        return StartCoroutine(PerformMove(direction));
    }

    protected virtual IEnumerator PerformMove(Direction direction)
    {
        bIsDefending = false;
        animaAnimator.SetBool("isDefending", bIsDefending);
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
        PlayActionSound(ActionType.Attack);

        bIsDefending = false;
        animaAnimator.SetBool("isDefending", bIsDefending);
        animaAnimator.SetInteger("attintck", (int) direction);
        animaAnimator.ResetTrigger("actriggerion");
        animaAnimator.SetTrigger("actriggerion");
        animaAnimator.SetInteger("dirintion", (int) direction);
        return StartCoroutine(PerformAttack(direction));
    }

    protected virtual IEnumerator PerformAttack(Direction direction)
    {
        yield return new WaitForSeconds(moveTime);
        Vector2Int attackCell = GetGridCell();
        switch(direction)
        {
            case Direction.North:
                attackCell += Vector2Int.up;
                break;
            case Direction.South:
                attackCell += Vector2Int.down;
                break;
            case Direction.East:
                attackCell += Vector2Int.right;
                break;
            case Direction.West:
                attackCell += Vector2Int.left;
                break;
        }
        IDamageable damageable = LevelGrid.Get().GetObjectAtGridPosition(attackCell) as IDamageable;
        if(damageable != null)
        {
            damageable.Damage();
        }

    }

    public virtual Coroutine StartDefend()
    {
        PlayActionSound(ActionType.Defend);
        bIsDefending = true;
        animaAnimator.SetBool("isDefending", bIsDefending);
        animaAnimator.SetTrigger("defTrig");
        return StartCoroutine(PerformDefend());
    }

    protected virtual IEnumerator PerformDefend()
    {
        yield return new WaitForSeconds(moveTime);
    }

    public void Damage()
    {
        if(bIsDefending)
        {
            bIsDefending = false;
            animaAnimator.SetBool("isDefending", bIsDefending);
            return;
        }
        health--;
        if(health < 1)
        {
            if(OnCharacterDeath != null)
            {
                OnCharacterDeath.Invoke();
            }
            OnDeath();
        }
    }

    protected virtual void OnDeath()
    {
        LevelGrid.Get().UnregisterLevelObject(this);
        Destroy(gameObject);
    }
}

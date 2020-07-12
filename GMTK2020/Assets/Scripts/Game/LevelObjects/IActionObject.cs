
using UnityEngine;

public interface IActionObject
{
    Coroutine StartMove(Direction direction);

    Coroutine StartAttack(Direction direction);

    Coroutine StartDefend();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActionObject
{
    Coroutine StartMove(Direction direction);

    Coroutine StartAttack();
}

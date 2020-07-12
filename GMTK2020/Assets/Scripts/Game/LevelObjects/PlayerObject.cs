using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : CharacterObject
{

    Animator bunnyAnimator;

    public override ObjectType GetObjectType() { return ObjectType.Player; }


    protected override void Start()
    {
        base.Start();

        LevelManager.Get().playerObject = this;
    }

    protected override IEnumerator PerformMove(Direction direction)
    {

        yield return base.PerformMove(direction);

    }

}

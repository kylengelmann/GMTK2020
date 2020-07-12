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
        Vector2Int pickupCell = GetGridCell();
        switch (direction)
        {
            case Direction.North:
                pickupCell += Vector2Int.up;
                break;
            case Direction.South:
                pickupCell += Vector2Int.down;
                break;
            case Direction.East:
                pickupCell += Vector2Int.right;
                break;
            case Direction.West:
                pickupCell += Vector2Int.left;
                break;
        }
        PickupObject pickup = LevelGrid.Get().GetObjectAtGridPosition(pickupCell) as PickupObject;
        yield return base.PerformMove(direction);
        if(pickup)
        {
            pickup.OnPickedUp();
        }
    }

}

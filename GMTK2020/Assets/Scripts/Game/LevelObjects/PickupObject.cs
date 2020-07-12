using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickupObject : LevelObject
{
    public override ObjectType GetObjectType() {return ObjectType.None;}

    public virtual void OnPickedUp()
    {
        LevelGrid.Get().UnregisterLevelObject(this);
        Destroy(gameObject);
    }
}

public enum PickupType
{
    Energy = 0,
    Cards = 1,
}
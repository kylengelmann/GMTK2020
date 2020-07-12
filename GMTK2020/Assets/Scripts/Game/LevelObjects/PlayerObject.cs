using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : CharacterObject
{
    public override ObjectType GetObjectType() { return ObjectType.Player; }


    protected override void Start()
    {
        base.Start();

        LevelManager.Get().playerObject = this;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : CharacterObject
{
    public override ObjectType GetObjectType() { return ObjectType.Enemy; }
}

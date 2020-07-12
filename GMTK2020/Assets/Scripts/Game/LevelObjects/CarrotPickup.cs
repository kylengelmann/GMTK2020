using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotPickup : PickupObject
{
    public override void OnPickedUp()
    {
        LevelManager.Get().hand.AddEnergy();
        base.OnPickedUp();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPickup : PickupObject
{
    public DeckData cardPackData;

    public override void OnPickedUp()
    {
        if(cardPackData)
        {
            GameManager.Get().AddCardPack(cardPackData);
            LevelManager.Get().DisplayCardPickup(cardPackData.pickupDisplay);
        }
        base.OnPickedUp();
    }
}

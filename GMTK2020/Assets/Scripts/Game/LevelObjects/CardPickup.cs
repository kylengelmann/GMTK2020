using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPickup : PickupObject
{
    public DeckData[] cardPackDatas;

    public override void OnPickedUp()
    {
        if(cardPackDatas.Length > 0)
        {
            DeckData cardPackData = cardPackDatas[Mathf.FloorToInt(Random.Range(0, cardPackDatas.Length))];
            GameManager.Get().AddCardPack(cardPackData);
            LevelManager.Get().deck.AddCardPack(cardPackData.cardData);
            LevelManager.Get().DisplayCardPickup(cardPackData.pickupDisplay);
        }
        base.OnPickedUp();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public CardData cardData {get; private set;}

    new BoxCollider2D collider2D;

    public void Awake()
    {
        collider2D = GetComponent<BoxCollider2D>();
    }

    public void SetCardData(CardData newCardData)
    {
        cardData = newCardData;
    }

    public void OnClicked()
    {

    }

    public void SetHover(bool bNewHover)
    {

    }

    public bool IsMouseHovering(Vector2 mousePositionWorld)
    {
        return collider2D.OverlapPoint(mousePositionWorld);
    }
}

[System.Serializable]
public struct CardData
{
    public ActionType[] actions;
    public int cost;
}
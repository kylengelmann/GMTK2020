using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public CardData cardData {get; private set;}

    new BoxCollider2D collider2D;

    bool bIsHovered = false;

    bool bIsActive = false;

    public void Awake()
    {
        collider2D = GetComponent<BoxCollider2D>();
    }

    public void SetCardData(CardData newCardData)
    {
        cardData = newCardData;
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = cardData.sprite;

    }

    public void OnClicked()
    {

    }

    public void SetHover(bool bNewHover)
    {
        if(bNewHover == bIsHovered) return;
        bIsHovered = bNewHover;

        transform.localScale = Vector3.one * (bIsHovered ? 1.2f : 1f);
    }

    public bool IsMouseHovering(Vector2 mousePositionWorld)
    {
        if(LevelManager.Get().hand.Energy < cardData.cost) return false;
        return collider2D.OverlapPoint(mousePositionWorld);
    }
}

[System.Serializable]
public struct CardData
{
    public ActionType[] actions;
    public int cost;
    public Sprite sprite;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public CardData cardData {get; private set;}
    public float hoveredScale = 1.2f;
    public Vector3 hoveredTranslation;
    public float selectedScale = .9f;
    public Vector3 selectedTranslation;

    new BoxCollider2D collider2D;

    bool bIsHovered = false;
    bool bIsClicked = false;

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

    public void SetClicked(bool bIsClicked)
    {
        if(this.bIsClicked == bIsClicked) return;
        this.bIsClicked = bIsClicked;
        transform.localScale = Vector3.one *(bIsClicked ? selectedScale : (bIsHovered ? hoveredScale : 1f));
        transform.localPosition = bIsClicked ? selectedTranslation : (bIsHovered ? hoveredTranslation : Vector3.zero);
    }


    public void SetHover(bool bNewHover)
    {
        if(bNewHover == bIsHovered || bIsClicked) return;
        bIsHovered = bNewHover;

        transform.localScale = Vector3.one * (bIsHovered ? hoveredScale : 1f);
        transform.localPosition = bIsHovered ? hoveredTranslation : Vector3.zero;
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
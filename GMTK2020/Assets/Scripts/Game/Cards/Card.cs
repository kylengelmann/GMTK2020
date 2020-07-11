using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public CardData cardData {get; private set;}

    public Sprite[] typeSprites;
    public HorizontalLayoutGroup typeGroup;
    public Text Cost;

    public GameObject typeImagePrefab;

    new BoxCollider2D collider2D;

    bool bIsHovered = false;

    public void Awake()
    {
        collider2D = GetComponent<BoxCollider2D>();
    }

    public void SetCardData(CardData newCardData)
    {
        cardData = newCardData;

        foreach(ActionType actionType in cardData.actions)
        {
            GameObject typeImageGO = Instantiate(typeImagePrefab, typeGroup.transform);
            typeImageGO.transform.localPosition = new Vector3(typeImageGO.transform.localPosition.x, typeImageGO.transform.localPosition.y, 0f);
            Image typeImage = typeImageGO.GetComponent<Image>();
            typeImage.sprite = typeSprites[(int)actionType];
        }

        Cost.text = cardData.cost.ToString();
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
        return collider2D.OverlapPoint(mousePositionWorld);
    }
}

[System.Serializable]
public struct CardData
{
    public ActionType[] actions;
    public int cost;
}
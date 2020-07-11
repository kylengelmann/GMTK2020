using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public GameObject cardPrefab;
    [SerializeField] private Transform[] cardPositions;
    private Card[] cards;
    public int NumCards {get; private set;}

    public Card hoveredCard { get; private set; }

    private void Start()
    {
        cards = new Card[cardPositions.Length];
        LevelManager.Get().OnLevelStateChange += OnLevelStateChange;
    }

    void OnLevelStateChange(LevelState levelState)
    {
        if(levelState == LevelState.PlayerTurn)
        {
            FillHand();
        }
    }

    public void FillHand()
    {
        while(NumCards < cardPositions.Length)
        {
            if(LevelManager.Get().deck.GetNumCards() < 1)
            {
                LevelManager.Get().ShuffleDiscardIntoDeck();
            }
            DrawCard();
        }
    }

    void DrawCard()
    {
        CreateCard(LevelManager.Get().deck.Draw());
    }

    void CreateCard(in CardData cardData)
    {
        GameObject newCardGO = Instantiate(cardPrefab);
        if (newCardGO)
        {
            Card newCard = newCardGO.GetComponent<Card>();
            if (newCard)
            {
                newCard.SetCardData(cardData);
                for(int i = 0; i < cards.Length; ++i)
                {
                    if(cards[i] == null)
                    {
                        cards[i] = newCard;
                        newCardGO.transform.parent = cardPositions[i];
                        newCardGO.transform.localScale = Vector3.one;
                        newCardGO.transform.localPosition = Vector3.zero;
                        NumCards++;
                        break;
                    }
                }
            }
            else
            {
                Destroy(newCardGO);
            }
        }
    }

    public void Discard(int cardIdx)
    {
        LevelManager.Get().discard.AddCardToEnd(cards[cardIdx].cardData);
        if(hoveredCard == cards[cardIdx])
        {
            hoveredCard = null;
        }

        Destroy(cards[cardIdx]);
        cards[cardIdx] = null;
        NumCards--;
    }

    public void OnClick()
    {

    }

    public void UpdateCardHover(Vector2 mousePositionWorld)
    {
        if (hoveredCard)
        {
            if (!hoveredCard.IsMouseHovering(mousePositionWorld))
            {
                hoveredCard = null;
            }
            else return;
        }

        foreach (Card card in cards)
        {
            if(card == null) continue;

            if (!hoveredCard)
            {
                if (card.IsMouseHovering(mousePositionWorld))
                {
                    hoveredCard = card;
                    card.SetHover(true);
                    continue;
                }
            }

            card.SetHover(false);
        }
    }
}

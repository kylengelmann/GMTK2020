using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    List<CardData> cards;

    public int GetNumCards() {return cards.Count;}

    public SpriteRenderer tens;
    public SpriteRenderer ones;

    public void Init(in DeckCardData[] inDeckData)
    {
        cards = new List<CardData>();

        if(inDeckData != null)
        {
            for(int i = 0; i < inDeckData.Length; ++i)
            {
                for(int j = 0; j < inDeckData[i].numCards; j++)
                {
                    cards.Add(inDeckData[i].cardData);
                }
            }
            Shuffle();
        }

        UpdateCardText();
    }

    void UpdateCardText()
    {
        int tensNum = Mathf.FloorToInt(GetNumCards()/10f);
        int onesNum = GetNumCards() % 10;

        tens.sprite = GameManager.Get().Didgets[tensNum];
        ones.sprite = GameManager.Get().Didgets[onesNum];
    }

    public void AddCardToEnd(in CardData cardData)
    {
        cards.Add(cardData);
        
        UpdateCardText();
    }

    public void AddAndShuffle(Deck deck)
    {
        cards.AddRange(deck.cards);
        deck.Empty();
        Shuffle();
        UpdateCardText();
    }

    void Shuffle()
    {
        for(int i = 0; i < cards.Count; ++i)
        {
            CardData temp = cards[i];
            int rand = Mathf.FloorToInt(Random.Range(0, cards.Count));
            cards[i] = cards[rand];
            cards[rand] = temp;
        }
    }

    public CardData Draw()
    {
        CardData retVal = cards[cards.Count - 1];
        cards.RemoveAt(cards.Count - 1);
        UpdateCardText();
        return retVal;
    }

    public void Empty()
    {
        cards.Clear();
        UpdateCardText();
    }
}

[System.Serializable]
public struct DeckCardData
{
    public CardData cardData;
    public int numCards;
}
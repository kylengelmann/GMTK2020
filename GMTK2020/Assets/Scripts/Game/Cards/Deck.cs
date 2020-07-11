using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    List<CardData> cards;

    public int GetNumCards() {return cards.Count;}

    public Text cardCount;

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

        cardCount.text = GetNumCards().ToString();
    }

    public void AddCardToEnd(in CardData cardData)
    {
        cards.Add(cardData);
        cardCount.text = GetNumCards().ToString();
    }

    public void AddAndShuffle(Deck deck)
    {
        cards.AddRange(deck.cards);
        deck.Empty();
        Shuffle();
        cardCount.text = GetNumCards().ToString();
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
        cardCount.text = GetNumCards().ToString();
        return retVal;
    }

    public void Empty()
    {
        cards.Clear();
        cardCount.text = GetNumCards().ToString();
    }
}

[System.Serializable]
public struct DeckCardData
{
    public CardData cardData;
    public int numCards;
}
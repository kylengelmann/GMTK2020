using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public GameObject cardPrefab;
    [SerializeField] private Transform[] cardPositions;
    private Card[] cards;
    public int NumCards {get; private set;}

    int hoveredCardIdx = -1;
    int selectedCardIdx = -1;
    public bool HasSelectedCard() {return selectedCardIdx > 0;}

    int actionIdx = 0;

    public int Energy { get; private set; }

    private void Start()
    {
        cards = new Card[cardPositions.Length];
        LevelManager.Get().OnLevelStateChange += OnLevelStateChange;
    }

    bool bIsLocked = true;
    public bool bPaused = false;

    void OnLevelStateChange(LevelState levelState)
    {
        if(levelState == LevelState.PlayerTurn)
        {
            bIsLocked = false;
            FillHand();
            Energy = GameManager.Get().MaxEnergy;
        }
        else
        {
            bIsLocked = true;
        }
    }

    public void FillHand()
    {
        while(NumCards < cardPositions.Length)
        {
            DrawCard();
        }
    }

    void DrawCard()
    {
        if (LevelManager.Get().deck.GetNumCards() < 1)
        {
            LevelManager.Get().ShuffleDiscardIntoDeck();
        }
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
        if(hoveredCardIdx == cardIdx)
        {
            hoveredCardIdx = -1;
        }
        if(selectedCardIdx == cardIdx)
        {
            selectedCardIdx = -1;
        }

        Destroy(cards[cardIdx].gameObject);
        cards[cardIdx] = null;
        NumCards--;
    }

    public void OnClick()
    {
        if(bIsLocked || bPaused) return;
        if(hoveredCardIdx >= 0)
        {
            selectedCardIdx = hoveredCardIdx;
            hoveredCardIdx = -1;
            cards[selectedCardIdx].SetClicked(true);
        }
    }

    public void OnDirectionSelected(Direction direction)
    {
        if (bIsLocked || bPaused) return;
        if (selectedCardIdx >= 0)
        {
            if(actionIdx >= cards[selectedCardIdx].cardData.actions.Length) return;

            ActionData actionData = new ActionData() {type = cards[selectedCardIdx].cardData.actions[actionIdx], direction = direction};
            ActionManager.Get().AddActionToQueue(actionData);
            ActionManager.Get().StartProcessingQueue(LevelManager.Get().playerObject);
            actionIdx++;

            if(actionIdx >= cards[selectedCardIdx].cardData.actions.Length)
            {
                StartCoroutine(DiscardAfterQueue());
            }
        }
    }

    IEnumerator DiscardAfterQueue()
    {
        while(ActionManager.Get().bIsProcessingQueue)
        {
            yield return null;
        }

        actionIdx = 0;
        Energy -= cards[selectedCardIdx].cardData.cost;
        Discard(selectedCardIdx);
    }

    public void OnEscapePressed()
    {
        if (bIsLocked || bPaused) return;
        if (selectedCardIdx >= 0)
        {
            if(actionIdx == 0)
            {
                cards[selectedCardIdx].SetClicked(false);
                selectedCardIdx = -1;
            }
        }
    }

    public void OnDiscardPressed()
    {
        if (bIsLocked || bPaused) return;
        if (selectedCardIdx >= 0)
        {
            if(actionIdx == 0)
            {
                Energy -= GameManager.Get().DiscardCost;
                Discard(selectedCardIdx);
                DrawCard();
            }
        }
    }

    public void UpdateCardHover(Vector2 mousePositionWorld)
    {
        if (selectedCardIdx >= 0)
        {
            bool bIsHovered = cards[selectedCardIdx].IsMouseHovering(mousePositionWorld);
            cards[selectedCardIdx].SetHover(bIsHovered);
            return;
        }

        if (hoveredCardIdx >= 0 && !bIsLocked && !bPaused)
        {
            if (!cards[hoveredCardIdx].IsMouseHovering(mousePositionWorld))
            {
                hoveredCardIdx = -1;
            }
            else return;
        }

        for(int cardIdx = 0; cardIdx < cards.Length; ++cardIdx)
        {
            Card card = cards[cardIdx];
            if(card == null) continue;

            if (hoveredCardIdx < 0 && !bIsLocked && !bPaused)
            {
                if (card.IsMouseHovering(mousePositionWorld))
                {
                    hoveredCardIdx = cardIdx;
                    card.SetHover(true);
                    continue;
                }
            }

            card.SetHover(false);
        }
    }

    public void AddEnergy()
    {
        Energy++;
    }
}

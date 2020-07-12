using UnityEngine;

[CreateAssetMenu(fileName = "New Deck", menuName = "GMTK/Deck")]
public class DeckData : ScriptableObject
{
    public DeckCardData[] cardData;
    public Sprite pickupDisplay;
}

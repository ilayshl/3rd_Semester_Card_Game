using UnityEngine;

public class Card
{
    public readonly CardSuit cardSuit;
    public readonly int cardRank;
    public readonly Sprite suitImage;

    public Card(CardSuit suit, int rank, Sprite suitImage)
    {
        cardSuit = suit;
        cardRank = rank;
        this.suitImage = suitImage;
    }
}

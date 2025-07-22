using UnityEngine;

public class Card
{
    public readonly CardSuit cardSuit;
    public readonly int cardRank;

    public Card(CardSuit suit, int rank)
    {
        cardSuit = suit;
        cardRank = rank;
    }
}

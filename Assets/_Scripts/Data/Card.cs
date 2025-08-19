using UnityEngine;

public class Card
{
    public readonly CardSuit Suit;
    public readonly int Rank;
    public readonly Sprite suitImage;

    public Card(CardSuit suit, int rank, Sprite suitImage)
    {
        Suit = suit;
        Rank = rank;
        this.suitImage = suitImage;
    }

    public override string ToString()
    {
        string cardDescription = string.Empty;
        switch (Rank)
        {
            case 11:
                cardDescription = "Prince";
                break;
            case 12:
                cardDescription = "Queen";
                break;
            case 13:
                cardDescription = "King";
                break;
            case 14:
                cardDescription = "Ace";
                break;
            default:
                cardDescription = Rank.ToString();
                break;
        }

        return $"{cardDescription} of {Suit}";
    }
}

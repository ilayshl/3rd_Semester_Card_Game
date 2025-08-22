using UnityEngine;

/// <summary>
/// Holds all information about a card.
/// </summary>
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

    /// <summary>
    /// Returns only the rank as a string.
    /// </summary>
    /// <returns></returns>
    public string RankToString()
    {
        string displayRank = Rank switch
        {
            11 => "Prince",
            12 => "Queen",
            13 => "King",
            14 => "Ace",
            _ => Rank.ToString()
        };
        return displayRank;
    }

    /// <summary>
    /// Returns the entire card name.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"{RankToString()} of {Suit}";
    }
}

using System.Collections.Generic;

/// <summary>
/// Experimental script to make Deck function like a Vector or a List -> Hold multiple fields of information of Cards
/// but functions as a variable
/// </summary>
public struct Deck
{
    public List<Card> deck;

    public Deck CreateDeck()
    {
        Deck thisDeck = new();
        thisDeck.deck = new();
        for (int i = 0; i <= 3; i++)
        {
            for (int j = 2; j <= 14; j++)
            {
                thisDeck.deck.Add(new Card((CardSuit)i, j));
            }
        }
        return thisDeck;
    }

    public Deck ShuffleDeck(Deck deckToShuffle)
    {
        Deck shuffledDeck = new();
        int originalCount = deckToShuffle.deck.Count;
        for (int i = 0; i < originalCount; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, deckToShuffle.deck.Count);
            shuffledDeck.deck.Add(deckToShuffle.deck[randomIndex]);
            deckToShuffle.deck.RemoveAt(randomIndex);
        }
        return shuffledDeck;
    }
}

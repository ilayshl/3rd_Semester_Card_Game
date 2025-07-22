using System.Collections.Generic;
using UnityEngine;

public static class DeckActions
{
    public static List<Card> CreateDeck(int suitsAmount, int ranksPerSuit)
    {
        List<Card> deckToCreate = new();
        for (int i = 0; i <= suitsAmount - 1; i++)
        {
            for (int j = 2; j <= ranksPerSuit + 1; j++)
            {
                deckToCreate.Add(new Card((CardSuit)i, j));
            }
        }
        return deckToCreate;
    }

    public static List<Card> ShuffleDeck(List<Card> deckToShuffle)
    {
        /*  Card[] copiedDeck = new Card[deckToShuffle.Count];
         deckToShuffle.CopyTo(copiedDeck); */
        List<Card> shuffledDeck = new();
        int originalCount = deckToShuffle.Count;
        for (int i = 0; i < originalCount; i++)
        {
            int randomIndex = Random.Range(0, deckToShuffle.Count);
            shuffledDeck.Add(deckToShuffle[randomIndex]);
            deckToShuffle.RemoveAt(randomIndex);
        }
        return shuffledDeck;
    } 
    
    /* Another version of shuffling:
     Card[] copiedDeck = new Card[deckToShuffle.Count];
        foreach (var card in deckToShuffle)
        {
            int randomIndex = Random.Range(0, copiedDeck.Length);
            while (copiedDeck[randomIndex] != null)
            {
                randomIndex = Random.Range(0, copiedDeck.Length);
            }
            copiedDeck[randomIndex] = card;
        }

        List<Card> shuffledDeck = new();

        foreach (var card in copiedDeck)
        {
            shuffledDeck.Add(card);
        }

            return shuffledDeck; */
}

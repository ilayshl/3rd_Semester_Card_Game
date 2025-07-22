using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    List<Card> myDeck = new();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myDeck = DeckActions.CreateDeck(4, 13);
        foreach (var card in myDeck)
        {
            Debug.Log($"My rank is {card.cardRank} and my suit is {card.cardSuit}");
        }
        Debug.Log($"Cards in deck: {myDeck.Count}");
        myDeck = DeckActions.ShuffleDeck(myDeck);
        Debug.Log("Shuffled!");
        foreach (var card in myDeck)
        {
            Debug.Log($"My rank is {card.cardRank} and my suit is {card.cardSuit}");
        }
        Debug.Log($"Cards in deck: {myDeck.Count}");




    }

    /* void SearchForDuplicates(Card[] origin, List<Card> shuffled)
    {
        foreach (var card in origin)
        {
            foreach (var shuffledCard in shuffled)
            {
                if (card.cardRank == shuffledCard.cardRank && card.cardSuit == shuffledCard.cardSuit)
                {
                    Debug.Log($"Found duplicate! {card.cardRank}, {card.cardSuit}");
                }
            }
        }
    } */
}

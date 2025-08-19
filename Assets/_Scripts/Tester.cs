using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Tester : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerOneDeckSize;
    [SerializeField] private TextMeshProUGUI playerTwoDeckSize;
    [SerializeField] private TextMeshProUGUI mainDeckSize;
    private Deck _mainDeck;
    private Deck playerOneDeck;
    private Deck playerTwoDeck;

    void Start()
    {
        Debug.Log("Ready to roll!");
    }

    public void CreateDeck(int suitsAmount)
    {
        _mainDeck = new Deck(suitsAmount, 13);
        Debug.Log(_mainDeck.ToString());
        UpdateDeckSizeText();
    }

    public void Shuffle()
    {
        //Checks if main deck even exists
        if (_mainDeck == null)
        {
            Debug.Log("[Tester] No deck to shuffle! Try creating a deck first.");
            return;
        }

        _mainDeck.ShuffleDeck();
        Debug.Log("Shuffled!");
        Debug.Log(_mainDeck.ToString());
    }

    public void DivideCards()
    {
        //Checks if main deck even exists
        if (_mainDeck == null)
        {
            Debug.Log("[Tester] No deck to shuffle! Try creating a deck first.");
            return;
        }

        //Checks if the deck's count is odd- if so, removes one card to make it even.
        if (_mainDeck.Count % 2 != 0)
        {
            _mainDeck.DrawCard();
        }

        int currentDeckCount = _mainDeck.Count;
        List<Card> temp = new(); //Temporary list to hold the information for player's decks
        //Moves 50% of cards from the top of the deck to player one's deck while keeping their order
        for (int i = currentDeckCount / 2 + 1; i <= currentDeckCount; i++)
        {
            //Adds card to temp AND removes from _mainDeck
            temp.Add(_mainDeck.DrawCardAt(_mainDeck.OriginalCount / 2));
        }
        playerOneDeck = new(temp); //Creates a new deck to correctly set OriginalCount's value
        temp = new();
        currentDeckCount = _mainDeck.Count;
        //Moves all remaining cards from the deck to player two's deck while keeping their order
        for (int i = 0; i < currentDeckCount; i++)
        {
            temp.Add(_mainDeck.DrawCardAt(0));
        }
        playerTwoDeck = new(temp); //Creates a new deck to correctly set OriginalCount's value
        Debug.Log(playerOneDeck.ToString());
        Debug.Log(playerTwoDeck.ToString());
        UpdateDeckSizeText();
    }

    public void Play()
    {
        Card playerOneCard = playerOneDeck.DrawCard();
        Card playerTwoCard = playerTwoDeck.DrawCard();
        Debug.Log(playerOneCard.ToString());
        Debug.Log(playerTwoCard.ToString());
        if (playerOneCard.Rank > playerTwoCard.Rank)
        {
            Debug.Log("Player 1 wins!");
            playerOneDeck.AddCard(playerOneCard);
            playerOneDeck.AddCard(playerTwoCard);
        }
        else if (playerOneCard.Rank < playerTwoCard.Rank)
        {
            Debug.Log("Player 2 wins!");
            playerTwoDeck.AddCard(playerOneCard);
            playerTwoDeck.AddCard(playerTwoCard);
        }
        else
        {
            Debug.Log("Tie!");
        }
        UpdateDeckSizeText();
    }

    private void UpdateDeckSizeText()
    {
        mainDeckSize.SetText($"{_mainDeck.Count} / {_mainDeck.OriginalCount}");
        if (playerOneDeck != null && playerTwoDeck != null)
        {
            playerOneDeckSize.SetText($"{playerOneDeck.Count} / {playerOneDeck.OriginalCount}");
            playerTwoDeckSize.SetText($"{playerTwoDeck.Count} / {playerTwoDeck.OriginalCount}");
        }
    }
}

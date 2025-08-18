using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tester : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerOneDeckSize;
    [SerializeField] private TextMeshProUGUI playerTwoDeckSize;
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
        //Moves all remaining cards from the deck to player two's deck while keeping their order
        for (int i = 0; i < _mainDeck.Count; i++)
        {
            temp.Add(_mainDeck.CardAt(i));
        }
        playerTwoDeck = new(temp); //Creates a new deck to correctly set OriginalCount's value
        _mainDeck = null;
        Debug.Log(playerOneDeck.ToString());
        Debug.Log(playerTwoDeck.ToString());
        UpdateDeckSizeText();
    }

    public void Play()
    {
        List<Card> mainDeck = _mainDeck.ToList();
    }

    private void UpdateDeckSizeText()
    {
        playerOneDeckSize.SetText($"{playerOneDeck.Count} / {playerOneDeck.OriginalCount}");
        playerTwoDeckSize.SetText($"{playerTwoDeck.Count} / {playerTwoDeck.OriginalCount}");
    }
}

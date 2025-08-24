using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Responsible for the WarGame phase's logic.
/// </summary>
public class WarGameHandler : Singleton<WarGameHandler>
{
    public WarGameState state;
    public Action<WarGameState> OnWarGameStateChanged; //Will later be used for automation
    [SerializeField] private TextMeshProUGUI playerOneDeckSize; //Will later be moved to UiManager
    [SerializeField] private TextMeshProUGUI playerTwoDeckSize;//Will later be moved to UiManager
    [SerializeField] private TextMeshProUGUI mainDeckSize; //Will later be moved to UiManager
    [SerializeField] private PlayerData[] players; //= new PlayerData[2];
    private Deck _mainDeck;

    /// <summary>
    /// Will be used later when GameManager will actually manage all minigames
    /// </summary>
    /// <param name="playerToAssign"></param>
    public void AssignPlayer(PlayerData playerToAssign)
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] == null)
            {
                players[i] = playerToAssign;
                return;
            }
        }
        Debug.LogWarning("Trying to add player when 2 player slots are taken!");
    }

//Will later be used for automation
    public void ChangeWarGameState(WarGameState newState)
    {
        switch (newState)
        {
            case WarGameState.DrawCards:

                break;
            case WarGameState.Evaluate:

                break;
            case WarGameState.PlayerOneWon:

                break;
            case WarGameState.PlayerTwoWon:

                break;
        }

        state = newState;
        OnWarGameStateChanged?.Invoke(state);
    }

    /// <summary>
    /// Creates a new game deck to be used to divide for the players.
    /// Currently 13 hard coded because I want to add "Game Settings"
    /// to help players decide how many ranks they want.
    /// </summary>
    /// <param name="suitsAmount"></param>
    public void CreateDeck(int suitsAmount)
    {
        _mainDeck = new Deck(suitsAmount, 13);
        UpdateDeckSizeText();
    }

    /// <summary>
    /// Shuffles the current game deck.
    /// </summary>
    public void Shuffle()
    {
        //Checks if main deck even exists
        if (_mainDeck == null)
        {
            Debug.Log("[WarGameHandler] No deck to shuffle! Try creating a deck first.");
            return;
        }

        _mainDeck.ShuffleDeck();
        Debug.Log("Shuffled!");
    }

    /// <summary>
    /// Divides half and half to the players.
    /// This method keeps the order of the original game deck, by FIFO.
    /// </summary>
    public void DivideCards()
    {
        //Checks if main deck even exists
        if (_mainDeck == null || _mainDeck.Count == 0)
        {
            Debug.Log("[WarGameHandler] No deck to divide! Try creating a deck first.");
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
        players[0].Deck = new(temp); //Creates a new deck to correctly set OriginalCount's value
        temp = new();
        currentDeckCount = _mainDeck.Count;
        //Moves all remaining cards from the deck to player two's deck while keeping their order
        for (int i = 0; i < currentDeckCount; i++)
        {
            temp.Add(_mainDeck.DrawCardAt(0));
        }
        players[1].Deck = new(temp); //Creates a new deck to correctly set OriginalCount's value

        foreach (var player in players)
        {
            Debug.Log(player.Deck.ToString());
        }
        UpdateDeckSizeText();
    }

    /// <summary>
    /// This tells the players to draw cards.
    /// </summary>
    public void Play()
    {
        Card[] drawnCards = new Card[players.Length];
        for (int i = 0; i < drawnCards.Length; i++)
        {
            drawnCards[i] = players[i].DrawCard();
        }
        UpdateDeckSizeText();

        CompareCards();
    }

    /// <summary>
    /// Check who won the round, then insert the cards to the winner's deck.
    /// </summary>
    private void CompareCards()
    {
        if (players[0].LastDrawnCard.Rank > players[1].LastDrawnCard.Rank)
        {
            Debug.Log("Player 1 wins!");
            for (int i = 0; i < players.Length; i++)
            {
                players[0].Deck.AddCardAtRandom(players[i].LastDrawnCard);
            }
        }
        else if (players[0].LastDrawnCard.Rank < players[1].LastDrawnCard.Rank)
        {
            Debug.Log("Player 1 wins!");
            for (int i = 0; i < players.Length; i++)
            {
                players[1].Deck.AddCardAtRandom(players[i].LastDrawnCard);
            }
        }
        else
        {
            Debug.Log("Tie!");
        }
        UpdateDeckSizeText();
    }

    /// <summary>
    /// Updates the UI- currently for development only.
    /// </summary>
    private void UpdateDeckSizeText()
    {
        mainDeckSize.SetText($"{_mainDeck.Count} / {_mainDeck.OriginalCount}");
        if (players[0].Deck != null && players[1].Deck != null)
        {
            playerOneDeckSize.SetText($"{players[0].Deck.Count} / {players[0].Deck.OriginalCount}");
            playerTwoDeckSize.SetText($"{players[1].Deck.Count} / {players[1].Deck.OriginalCount}");
        }
    }
}

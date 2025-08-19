using System.Collections.Generic;
using UnityEngine;


public class Deck
{
    public int Count { get => _deck.Count; }
    public int OriginalCount { get; private set; }
    private List<Card> _deck;

    public Deck(int suitsAmount = 4, int rankPerSuit = 13)
    {
        CreateDeck(suitsAmount, rankPerSuit);
    }

    public Deck(List<Card> deck)
    {
        _deck = deck;
        OriginalCount = _deck.Count;
    }

    private void CreateDeck(int suitsAmount, int ranksPerSuit)
    {
        List<Card> deckToCreate = new();
        for (int i = 0; i <= suitsAmount - 1; i++)
        {
            for (int j = 2; j <= ranksPerSuit + 1; j++)
            {
                deckToCreate.Add(CardFactory.Instance.CreateCard(j, (CardSuit)i));
            }
        }
        _deck = deckToCreate;
        OriginalCount = _deck.Count;
    }

    public void ShuffleDeck()
    {
        List<Card> shuffledDeck = new();
        int originalCount = _deck.Count;
        for (int i = 0; i < originalCount; i++)
        {
            int randomIndex = Random.Range(0, _deck.Count);
            shuffledDeck.Add(_deck[randomIndex]);
            _deck.RemoveAt(randomIndex);
        }
        _deck = shuffledDeck;
    }

    public void AddCard(Card card)
    {
        _deck.Add(card);
    }

    public Card DrawCard()
    {
        Card cardDrawn = _deck[_deck.Count-1];
        _deck.RemoveAt(_deck.Count-1);
        return cardDrawn;
    }

    public override string ToString()
    {
        if (_deck == null || _deck.Count == 0) return "[Deck] Deck is empty.";

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        foreach (var card in _deck)
        {
            sb.AppendLine($"My rank is {card.Rank} and my suit is {card.Suit}");
        }
        sb.AppendLine($"Total cards in deck: {Count} out of: {OriginalCount}");
        return sb.ToString();
    }

    public List<Card> ToList()
    {
        return this._deck;
    }

    public Card CardAt(int index)
    {
        return _deck[index];
    }

    public Card DrawCardAt(int index)
    {
        Card cardDrawn = _deck[index];
        _deck.RemoveAt(index);
        return cardDrawn;
    }
}

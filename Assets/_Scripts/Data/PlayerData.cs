using System;
using UnityEngine;

/// <summary>
/// Holds all important data of the player.
/// This script will be on every player.
/// </summary>
public class PlayerData : MonoBehaviour
{
    public Action<Card> OnCardDrawn;
    public int WarPoints;
    public int RoundsWon;
    public Deck Deck;
    public Card LastDrawnCard { get; private set; }

    /// <summary>
    /// Draws a card and lets all subscribed scripts know it has drawn a card.
    /// </summary>
    /// <returns></returns>
    public Card DrawCard()
    {
        LastDrawnCard = Deck.DrawCard();
        OnCardDrawn?.Invoke(LastDrawnCard);
        return LastDrawnCard;
    }

}

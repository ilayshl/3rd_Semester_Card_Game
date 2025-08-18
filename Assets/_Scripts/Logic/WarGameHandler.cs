using System.Collections.Generic;
using UnityEngine;

public class WarGameHandler : Singleton<WarGameHandler>
{
    private Deck deck;

    public void StartNewGame()
    {
        deck = new();
    }
}

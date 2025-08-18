using UnityEngine;
using UnityEngine.UI;

public class CardFactory : Singleton<CardFactory>
{
    [SerializeField] private Sprite[] suitSprites;
    public Card CreateCard(int rank, CardSuit suit)
    {
        Card cardToCreate = new Card(suit, rank, suitSprites[(int)suit]);
        return cardToCreate;
    }
}

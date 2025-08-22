using UnityEngine;

/// <summary>
/// Creates a new Card or CardView object.
/// </summary>
public class CardFactory : Singleton<CardFactory>
{
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Sprite[] suitSprites;

    public Card CreateCard(int rank, CardSuit suit)
    {
        Card cardToCreate = new Card(suit, rank, suitSprites[(int)suit]);
        return cardToCreate;
    }

    /// <summary>
    /// Instnatiates a new CardView object that can be controlled later.
    /// </summary>
    /// <param name="cardParent"></param>
    /// <param name="cardData"></param>
    /// <returns></returns>
    public CardView InstantiateCardObject(Transform cardParent, Card cardData)
    {
        GameObject createdCardObject = Instantiate(cardPrefab, cardParent);
        CardView cardView = createdCardObject.GetComponent<CardView>();
        cardView.Setup(CreateCard(cardData.Rank, cardData.Suit));
        return cardView;
    }
}

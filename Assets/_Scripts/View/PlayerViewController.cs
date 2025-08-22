using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

/// <summary>
/// Responsible for viewing and moving the cards that the player draws.
/// This script will be on every player.
/// </summary>
public class PlayerViewController : MonoBehaviour
{
    [SerializeField] Canvas DrawnCardsCanvas;
    [SerializeField] Transform playerDeckPosition;
    [SerializeField] Transform drawnCardsDeckPosition;
    private PlayerData playerData;
    private List<CardView> activeCards = new();

    void Awake()
    {
        playerData = GetComponent<PlayerData>();
    }

    void OnEnable()
    {
        playerData.OnCardDrawn += CardDrawn;
    }

    void OnDisable()
    {
        playerData.OnCardDrawn -= CardDrawn;
    }

    /// <summary>
    /// When a card is drawn, this method creates it and moves it accordingly.
    /// </summary>
    /// <param name="card"></param>
    private void CardDrawn(Card card)
    {
        CardView spawnedCard = CardFactory.Instance.InstantiateCardObject(DrawnCardsCanvas.transform, card);
        spawnedCard.transform.position = transform.position;
        activeCards.Add(spawnedCard);
        Sequence seq = DOTween.Sequence();
        seq.Append(spawnedCard.transform.DOMove(drawnCardsDeckPosition.position, 0.5f)).SetEase(Ease.OutSine)
           .Append(spawnedCard.Flip()) //Doesn't work for some reason
           .OnComplete(OnDrawAnimationFinished);

    }

    /// <summary>
    /// To make the game better optimized- whenever too many card objects are on the screen, it removes some of them.
    /// </summary>
    private void OnDrawAnimationFinished()
    {
        if (activeCards.Count > 3)
        {
            Destroy(activeCards[0].gameObject);
            activeCards.RemoveAt(0);
        }
    }



}

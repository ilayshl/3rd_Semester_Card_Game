using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cardRank;
    [SerializeField] private Image cardSuit;
    private Card card;
    private bool isFlipped = false;

    public void Setup(Card card)
    {
        this.card = card;
        cardRank.SetText(card.Rank.ToString());
        cardSuit.sprite = card.suitImage;
    }

    private void Flip(float flipDuration = 0.25f)
    {
        isFlipped = !isFlipped;
        transform.DORotate(new(0, isFlipped ? 0f : 180f, 0), flipDuration);
    }
    
}

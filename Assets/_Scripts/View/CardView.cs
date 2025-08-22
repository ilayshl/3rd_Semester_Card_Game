using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Holds the view of the card object.
/// </summary>
public class CardView : MonoBehaviour
{
    public Card card { get; private set; }
    [SerializeField] private TextMeshProUGUI cardRank;
    [SerializeField] private Image cardSuit;
    private bool isFlipped = false;

    private void Start()
    {
        this.gameObject.name = card.ToString();
    }

    /// <summary>
    /// Get the data from the Card given.
    /// </summary>
    /// <param name="card"></param>
    public void Setup(Card card)
    {
        this.card = card;
        cardRank.SetText(card.RankToString());
        cardSuit.sprite = card.suitImage;
    }

    /// <summary>
    /// Flips the object 180 degrees, currently unused.
    /// </summary>
    /// <param name="flipDuration"></param>
    /// <returns></returns>
    public Tween Flip(float flipDuration = 0.25f)
    {
        isFlipped = !isFlipped;
        return transform.DORotate(new(0, isFlipped ? 0f : 180f, 0), flipDuration);
    }

}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ReelController : MonoBehaviour
{
    [Header("Reel Setup")]
    public RectTransform reelStrip;
    public Image[] symbolSlots;
    public Sprite[] symbols;

    [Header("Spin Settings")]
    public float spinSpeed = 1200f;
    public float stopDelay = 0.2f;

    private bool isSpinning = false;

    // Called by SlotManager to spin this reel
    public IEnumerator SpinToSymbol(int targetIndex, float duration)
    {
        isSpinning = true;
        float elapsed = 0f;
        float currentSpeed = spinSpeed;

        // Fast spin phase
        while (elapsed < duration)
        {
            // Slow down at the end - smooth stop effect
            float t = elapsed / duration;
            currentSpeed = Mathf.Lerp(spinSpeed, 150f, t);

            // Move strip down
            reelStrip.anchoredPosition += Vector2.down * currentSpeed * Time.deltaTime;

            // Loop symbols - infinite scroll effect
            if (reelStrip.anchoredPosition.y <= -120f)
            {
                reelStrip.anchoredPosition += new Vector2(0, 120f);
                ShuffleTopSymbol();
            }

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Snap to final symbol
        SetFinalSymbol(targetIndex);
        isSpinning = false;
    }

    void ShuffleTopSymbol()
    {
        // Random symbol while spinning for blur effect
        int random = Random.Range(0, symbols.Length);
        symbolSlots[0].sprite = symbols[random];
    }

    void SetFinalSymbol(int index)
    {
        // Middle slot shows the result
        symbolSlots[1].sprite = symbols[index];
        // Top and bottom show neighbours for realism
        int prev = (index - 1 + symbols.Length) % symbols.Length;
        int next = (index + 1) % symbols.Length;
        symbolSlots[0].sprite = symbols[prev];
        symbolSlots[2].sprite = symbols[next];

        // Reset strip position
        reelStrip.anchoredPosition = Vector2.zero;
    }

    public bool IsSpinning()
    {
        return isSpinning;
    }
}

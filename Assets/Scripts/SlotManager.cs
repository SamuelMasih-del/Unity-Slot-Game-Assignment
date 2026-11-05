using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotManager : MonoBehaviour
{
    [Header("Reels")]
    public Reel[] reels = new Reel[3];
    public Sprite[] symbols;

    [Header("UI")]
    public Button spinButton;
    public TextMeshProUGUI balanceText;
    public TextMeshProUGUI betText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI messageText;

    [Header("Settings")]
    public int balance = 1000;
    public int betAmount = 50;
    public float spinDuration = 1.2f;

    private bool isSpinning = false;
    private int[] result = new int[3];

    void Start()
    {
        spinButton.onClick.AddListener(OnSpinClicked);
        UpdateUI();
        winText.text = "";
        messageText.text = "Good Luck!";
    }

    public void OnSpinClicked()
    {
        if (isSpinning) return;
        if (balance < betAmount)
        {
            messageText.text = "Not enough balance! Reset to play again.";
            return;
        }

        balance -= betAmount;
        winText.text = "";
        messageText.text = "Spinning...";
        UpdateUI();
        StartCoroutine(SpinRoutine());
    }

    IEnumerator SpinRoutine()
    {
        isSpinning = true;
        spinButton.interactable = false;

        // RNG - Random result for each reel
        for (int i = 0; i < 3; i++)
        {
            result[i] = Random.Range(0, symbols.Length);
        }

        // Spin reels one by one with delay for smooth effect
        for (int i = 0; i < 3; i++)
        {
            StartCoroutine(reels[i].SpinReel(result[i], spinDuration + i * 0.5f));
            yield return new WaitForSeconds(0.3f);
        }

        // Wait for all reels to stop
        yield return new WaitForSeconds(spinDuration + 1.0f);

        CheckWin();
        isSpinning = false;
        spinButton.interactable = true;
    }

    void CheckWin()
    {
        int winAmount = 0;
        string msg = "";

        // 3 of a kind - Jackpot
        if (result[0] == result[1] && result[1] == result[2])
        {
            // Higher symbol index = higher payout
            int multiplier = 10 + (result[0] * 5);
            winAmount = betAmount * multiplier;
            msg = "JACKPOT! 3 of a Kind!";
        }
        // Any 2 match
        else if (result[0] == result[1] || result[1] == result[2] || result[0] == result[2])
        {
            winAmount = betAmount * 2;
            msg = "Nice! 2 Matched!";
        }
        else
        {
            msg = "Try Again!";
        }

        if (winAmount > 0)
        {
            balance += winAmount;
            winText.text = "+ " + winAmount;
            messageText.text = msg;
        }
        else
        {
            messageText.text = msg;
        }

        UpdateUI();
    }

    public void IncreaseBet()
    {
        if (betAmount < 200) betAmount += 10;
        UpdateUI();
    }

    public void DecreaseBet()
    {
        if (betAmount > 10) betAmount -= 10;
        UpdateUI();
    }

    public void ResetGame()
    {
        balance = 1000;
        betAmount = 50;
        winText.text = "";
        messageText.text = "Game Reset! Good Luck!";
        UpdateUI();
    }

    void UpdateUI()
    {
        balanceText.text = "Balance: " + balance;
        betText.text = "Bet: " + betAmount;
    }
}

[System.Serializable]
public class Reel
{
    public Image[] symbolImages; // 3 visible slots in reel
    public float spinSpeed = 20f;

    public IEnumerator SpinReel(int finalSymbolIndex, float duration)
    {
        float elapsed = 0f;
        // Fast spinning animation - cycle random symbols
        while (elapsed < duration)
        {
            // Shift symbols down visually by randomizing
            for (int i = 0; i < symbolImages.Length; i++)
            {
                // This will be replaced by actual sprites in SlotManager
                symbolImages[i].transform.localPosition += Vector3.down * spinSpeed * Time.deltaTime;
                if (symbolImages[i].transform.localPosition.y < -100)
                    symbolImages[i].transform.localPosition = new Vector3(0, 100, 0);
            }
            elapsed += Time.deltaTime;
            yield return null;
        }
        // Set final result - middle image shows result
        // Note: Final sprite is set from SlotManager in full version
    }
}

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Texts")]
    public TextMeshProUGUI balanceText;
    public TextMeshProUGUI betText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI messageText;

    [Header("Buttons")]
    public Button spinButton;
    public Button betPlusButton;
    public Button betMinusButton;
    public Button resetButton;

    [Header("Win Effect")]
    public GameObject winPanel;
    public ParticleSystem winParticles;

    public void UpdateBalance(int balance)
    {
        balanceText.text = "Balance: " + balance;
    }

    public void UpdateBet(int bet)
    {
        betText.text = "Bet: " + bet;
    }

    public void ShowWin(int winAmount, string message)
    {
        winText.text = "+ " + winAmount;
        messageText.text = message;
        messageText.color = Color.green;

        if (winPanel != null)
            winPanel.SetActive(true);

        if (winParticles != null)
            winParticles.Play();
    }

    public void ShowLose(string message)
    {
        winText.text = "";
        messageText.text = message;
        messageText.color = Color.white;

        if (winPanel != null)
            winPanel.SetActive(false);
    }

    public void SetSpinButton(bool canSpin)
    {
        spinButton.interactable = canSpin;
        spinButton.GetComponentInChildren<TextMeshProUGUI>().text = canSpin ? "SPIN" : "SPINNING...";
    }

    public void ShowJackpot()
    {
        messageText.text = "JACKPOT!!!";
        messageText.color = Color.yellow;
        messageText.fontSize = 48;
    }
}

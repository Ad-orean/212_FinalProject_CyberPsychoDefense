using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI waveText;

    void Start()
    {
        if (GameManager.Instance == null) return;

        GameManager.Instance.onMoneyChanged.AddListener(UpdateUI);
        GameManager.Instance.onLivesChanged.AddListener(UpdateUI);
        UpdateUI();
    }

    void UpdateUI()
    {
        if (moneyText != null)
            moneyText.text = "Money: " + GameManager.Instance.money;
        if (livesText != null)
            livesText.text = "Lives: " + GameManager.Instance.lives;
        if (waveText != null)
            waveText.text = "Wave: " + GameManager.Instance.currentWave;
    }
}
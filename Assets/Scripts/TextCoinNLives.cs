using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextCoinNLives : MonoBehaviour
{
    private CoinsManager coinsManager;
    private HealthManager healthManager;

    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI livesText;

    private void Awake()
    {
        coinsManager = Object.FindFirstObjectByType<CoinsManager>();
        healthManager = Object.FindFirstObjectByType<HealthManager>();
    }

    private void Update()
    {
        UpdateCoins();
        UpdateLives();
    }

    private void UpdateCoins()
    {
        coinsText.text = coinsManager.coinCount.ToString();
    }

    private void UpdateLives()
    {
        livesText.text = healthManager.lives.ToString();
    }

}

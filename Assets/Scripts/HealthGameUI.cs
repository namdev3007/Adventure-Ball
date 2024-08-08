using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class HealthGameUI : MonoBehaviour
{
    private HealthManager healthManager;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public TextMeshProUGUI livesText;

    PauseMenu pauseMenu;

    private void Awake()
    {
        pauseMenu = Object.FindFirstObjectByType<PauseMenu>();
        healthManager = Object.FindFirstObjectByType<HealthManager>();
    }

    private void Update()
    {
        if (healthManager.health <= 0)
        {
            healthManager.lives--;

            healthManager.health = 3;

            pauseMenu.GameOver();

            healthManager.SaveLives();
        }
        UpdateHearts();
        UpdateLives();
    }

    private void UpdateHearts()
    {
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < healthManager.health; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }



    private void UpdateLives()
    {
        livesText.text = healthManager.health.ToString();
    }
}

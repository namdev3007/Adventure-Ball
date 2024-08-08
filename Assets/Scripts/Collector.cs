using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    public GameObject prefabsCoinFX;

    public GameObject prefabsFX;
    public SpriteRenderer spriteRenderer;

    private CoinsManager coinsManager;
    private SceneController controller;
    private HealthManager healthManager;
    private PauseMenu pauseMenu;

    AudioManager audioManager;

    private void Awake()
    {
        coinsManager = Object.FindFirstObjectByType<CoinsManager>();
        controller = Object.FindFirstObjectByType<SceneController>();
        healthManager = Object.FindFirstObjectByType<HealthManager>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        pauseMenu = GameObject.FindFirstObjectByType<PauseMenu>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            coinsManager.coinCount += 50;
            Destroy(collision.gameObject);
            audioManager.PlaySFX(audioManager.coinCollect);
            GameObject particle = Instantiate(prefabsCoinFX, collision.transform.position, Quaternion.identity);
            Destroy(particle, 0.5f);
        }

        if(collision.gameObject.CompareTag("Gate"))
        {
            Invoke("LoadNextScene", 1f);
            audioManager.PlaySFX(audioManager.nextScene);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            coinsManager.coinCount += 100;
            StartCoroutine(DestroyAfterDelay(collision.gameObject, 0.1f));
            audioManager.PlaySFX(audioManager.EnemyCollect);
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            pauseMenu.GameOver();

            audioManager.PlaySFX(audioManager.dead);
            healthManager.lives--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            audioManager.PlaySFX(audioManager.Enemy);

            healthManager.health--;
        }
        if (collision.gameObject.CompareTag("Mistake"))
        {

            audioManager.PlaySFX(audioManager.dead);
            healthManager.health--;
        }
    }

    IEnumerator DestroyAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(obj);
    }
    void LoadNextScene()
    {
        controller.NextScene();
    }


    public void DeathFX()
    {
        spriteRenderer.enabled = false;
        Instantiate(prefabsFX, transform.position, Quaternion.identity);
    }

}

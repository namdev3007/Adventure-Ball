using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    private SceneController sceneController;
    private Collector collector;

    public GameObject pausePanel;
    public GameObject gameOver;


    public AudioSource audioSourceMusic;
    public AudioSource audioSourceSFX;

    public Image Image1;
    public Image Image2;
    bool muted1 = false;
    bool muted2 = false;

    private void Awake()
    {
        sceneController = Object.FindFirstObjectByType<SceneController>();
        collector = Object.FindFirstObjectByType<Collector>();
    }

    private void Start()
    {
        if(!PlayerPrefs.HasKey("muted1"))
        {
            PlayerPrefs.SetInt("muted1", 0);
            Load1();
        }
        else
        {
            Load1();
        }
        if (!PlayerPrefs.HasKey("muted2"))
        {
            PlayerPrefs.SetInt("muted2", 0);
            Load2();
        }
        else
        {
            Load2();
        }
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Continue()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Reload()
    {
        pausePanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void BackHome()
    {
        sceneController.PreviousScene();
    }    

    public void GameOver()
    {
        gameOver.SetActive(true);
        Invoke("SetTimeScaleToZero", 0.5f);

        collector.DeathFX();
    }

    void SetTimeScaleToZero()
    {
        Time.timeScale = 0f;
    }

    public void SkipLevel()
    {
        sceneController.SkipScene();
    }

    public void OnBntMusicPress()
    {
        if(muted1 ==  false)
        {
            muted1 = true;
            audioSourceMusic.Stop();

            Image1.enabled = false;
        }
        else
        {
            muted1 = false;
            audioSourceMusic.Play();

            Image1.enabled = true;
        }
        Save1();
    }

    public void OnBntSFXPress()
    {
        if (muted2 == false)
        {
            muted2 = true;
            audioSourceSFX.Stop();

            Image2.enabled = false;
        }
        else
        {
            muted2 = false;
            audioSourceSFX.Play();

            Image2.enabled = true;
        }
        Save2();
    }

    private void Load1()
    {
        muted1 = PlayerPrefs.GetInt("muted1") == 1;
    }
    private void Save1()
    {
        PlayerPrefs.SetInt("muted1", muted1 ? 1 : 0);
    }

    private void Load2()
    {
        muted2 = PlayerPrefs.GetInt("muted2") == 1;
    }
    private void Save2()
    {
        PlayerPrefs.SetInt("muted2", muted1 ? 1 : 0);
    }
}

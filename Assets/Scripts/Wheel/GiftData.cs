using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class GiftData : MonoBehaviour
{
    private CoinsManager coinsManager;
    private HealthManager healthManager;

    public GameObject popUp1;
    public GameObject popUp2;
    public GameObject popUp3;
    public GameObject popUp4;
    public GameObject popUp5;
    public GameObject popUp6;
    public GameObject popUp7;
    public GameObject popUp8;
    public GameObject popUp9;

    public CharacterDatabase characterDB;


    private void Awake()
    {
        coinsManager = Object.FindFirstObjectByType<CoinsManager>();
        healthManager = Object.FindFirstObjectByType<HealthManager>();
    }

    public void ShowPopup1()
    {
        popUp1.SetActive(true);
    }

    public void OnAcceptButton1()
    {
        coinsManager.coinCount += 6000;
        coinsManager.SaveCoinCount();
        popUp1.SetActive(false);
    }

    public void OnAcceptButton11()
    {
        coinsManager.coinCount += 3000;
        coinsManager.SaveCoinCount();
        popUp1.SetActive(false);
    }

    public void ShowPopup2()
    {
        popUp2.SetActive(true);
    }

    public void OnAcceptButton2()
    {
        healthManager.lives += 2;
        healthManager.SaveLives();
        popUp2.SetActive(false);
    }

    public void OnAcceptButton22()
    {
        healthManager.lives += 1;
        healthManager.SaveLives();
        popUp2.SetActive(false);
    }

    public void ShowPopup3()
    {
        popUp3.SetActive(true);
    }

    public void OnAcceptButton3()
    {
        coinsManager.coinCount += 4000;
        coinsManager.SaveCoinCount();
        popUp3.SetActive(false);
    }

    public void OnAcceptButton33()
    {
        coinsManager.coinCount += 2000;
        coinsManager.SaveCoinCount();
        popUp3.SetActive(false);
    }

    public void ShowPopup4()
    {
        popUp4.SetActive(true);
    }

    public void OnAcceptButton4()
    {
        popUp4.SetActive(false);
    }

    public void ShowPopup5()
    {
        popUp5.SetActive(true);
    }

    public void OnAcceptButton5()
    {
        healthManager.lives += 4;
        healthManager.SaveLives();
        popUp5.SetActive(false);
    }

    public void OnAcceptButton55()
    {
        healthManager.lives += 2;
        healthManager.SaveLives();
        popUp5.SetActive(false);
    }

    public void ShowPopup6()
    {
        popUp6.SetActive(true);
    }

    public void OnAcceptButton6()
    {
        popUp6.SetActive(false);
    }

    public void ShowPopup7()
    {
        popUp7.SetActive(true);
    }

    public void OnAcceptButton7()
    {
        coinsManager.coinCount += 2000;
        coinsManager.SaveCoinCount();
        popUp7.SetActive(false);
    }

    public void OnAcceptButton77()
    {
        coinsManager.coinCount += 1000;
        coinsManager.SaveCoinCount();
        popUp7.SetActive(false);
    }

    public void ShowPopup8()
    {
        popUp8.SetActive(true);
    }
    public void OnAcceptButton8()
    {
        popUp8.SetActive(false);
    }

    public void ShowPopup9()
    {
        popUp9.SetActive(true);
    }

    public void OnAcceptButton9()
    {
        healthManager.lives += 6;
        healthManager.SaveLives();
        popUp9.SetActive(false);
    }

    public void OnAcceptButton99()
    {
        healthManager.lives += 3;
        healthManager.SaveLives();
        popUp9.SetActive(false);
    }
}

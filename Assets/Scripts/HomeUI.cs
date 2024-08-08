using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : MonoBehaviour
{

    [Header("Shop UI")]
    public GameObject shopUI;
    public GameObject wheelUI;
    public GameObject gitfUI;
    public void TurnOnShop()
    {
        shopUI.SetActive(true);
    }

    public void TurnOffShop()
    {
        shopUI.SetActive(false);
    } 
    public void TurnOnGift()
    {
        gitfUI.SetActive(true);
    }
    public void TurnOnWheel()
    {
        wheelUI.SetActive(true);
    }
}

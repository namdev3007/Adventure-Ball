using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Spin : MonoBehaviour
{
    public int numberOfGifts = 9;
    public float timeRotate;
    public float numberCircleRotate;

    private const float circle = 360.0f;
    private float angleOfGift;

    public Transform parrent;
    private float currentTime;

    public AnimationCurve curve;

    public CoinsManager coinsManager;

    HealthManager healthManager;

    GiftData giftData;
    public CharacterDatabase characterDB;

    private void Awake()
    {
        healthManager = Object.FindFirstObjectByType<HealthManager>();
        giftData = Object.FindFirstObjectByType<GiftData>();
    }

    private void Start()
    {
        angleOfGift = circle / numberOfGifts;
        SetPositionData();
    }

    IEnumerator RotateWheel()
    {
        float starAngle = transform.eulerAngles.z;
        currentTime = 0;
        int indexGiftRandom = Random.Range(1, numberOfGifts);
        Debug.Log(indexGiftRandom);

        float angleWant = (numberCircleRotate * circle) + angleOfGift * indexGiftRandom - starAngle;

        while (currentTime < timeRotate)
        {
            yield return new WaitForEndOfFrame();
            currentTime += Time.deltaTime;

            float angleCurrent = angleWant * curve.Evaluate(currentTime / timeRotate);
            this.transform.eulerAngles = new Vector3(0, 0, angleCurrent + starAngle);
        }

        switch (indexGiftRandom)
        {
            case 1:
                giftData.ShowPopup1();
                break;
            case 2:
                giftData.ShowPopup2();
                break;
            case 3:
                giftData.ShowPopup3();
                break;
            case 4:
                giftData.ShowPopup4();
                characterDB.characters[5].unlocked = true;
                break;
            case 5:
                giftData.ShowPopup5();
                break;
            case 6:
                characterDB.characters[6].unlocked = true;
                giftData.ShowPopup6();
                break;
            case 7:
                giftData.ShowPopup7();
                break;
            case 8:
                characterDB.characters[7].unlocked = true;
                giftData.ShowPopup8();
                break;
            case 9:
                giftData.ShowPopup9();
                break;
            default:
                break;
        }



    }
    public void RotateNow()
    {
        StartCoroutine(RotateWheel());
    }

    void SetPositionData()
    {
        for (int i = 0; i < parrent.childCount; i++)
        {
            parrent.GetChild(i).eulerAngles = new Vector3(0, 0, -circle / numberOfGifts * i);
            parrent.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = (i + 1).ToString();
        }
    }
}
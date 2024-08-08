using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LiveEffect : MonoBehaviour
{
    [SerializeField] private GameObject pileOfLives;
    [SerializeField] private Vector2[] initialPos;
    [SerializeField] private Quaternion[] initialRotation;
    [SerializeField] private int livesAmount;

    void Start()
    {
        DOTween.SetTweensCapacity(500, 50);

        if (livesAmount == 0)
            livesAmount = 10;

        initialPos = new Vector2[livesAmount];
        initialRotation = new Quaternion[livesAmount];

        for (int i = 0; i < pileOfLives.transform.childCount; i++)
        {
            initialPos[i] = pileOfLives.transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition;
            initialRotation[i] = pileOfLives.transform.GetChild(i).GetComponent<RectTransform>().rotation;

        }
    }

    public void LivesEffect()
    {
        pileOfLives.SetActive(true);
        var delay = 0f;

        for (int i = 0; i < pileOfLives.transform.childCount; i++)
        {
            pileOfLives.transform.GetChild(i).DOScale(1f, 0.3f).SetDelay(delay).SetEase(Ease.OutBack);

            pileOfLives.transform.GetChild(i).GetComponent<RectTransform>().DOAnchorPos(new Vector2(471, 447), 0.8f)
                .SetDelay(delay + 0.5f).SetEase(Ease.InBack);


            pileOfLives.transform.GetChild(i).DORotate(Vector3.zero, 0.5f).SetDelay(delay + 0.5f)
                .SetEase(Ease.Flash);


            pileOfLives.transform.GetChild(i).DOScale(0f, 0.3f).SetDelay(delay + 1.5f).SetEase(Ease.OutBack);

            delay += 0.1f;

        }

        StartCoroutine(UpdateCounter());
    }

    IEnumerator UpdateCounter()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        PlayerPrefs.SetInt("CountLives", PlayerPrefs.GetInt("CountLives") + 50 + PlayerPrefs.GetInt("BPrize"));
        PlayerPrefs.SetInt("BPrize", 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    private Image imageComponent;

    [SerializeField] private Sprite faceSprite, backSprite;
    [SerializeField] private float rotateSpeed = 180f; // Tốc độ xoay

    public bool coroutineAllowed;

    private void Start()
    {
        imageComponent = GetComponent<Image>();
        // Kiểm tra nếu đã lưu trạng thái thẻ trước đó
        if (PlayerPrefs.GetInt("CardFlipped", 0) == 1)
        {
            imageComponent.sprite = faceSprite;
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            coroutineAllowed = false;
        }
        else
        {
            imageComponent.sprite = backSprite;
            coroutineAllowed = true;
        }
    }

    public void OnCardClicked()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(RotateCard());
            PlayerPrefs.SetInt("CardFlipped", 1);
        }
    }

    private IEnumerator RotateCard()
    {
        coroutineAllowed = false;
        imageComponent.sprite = faceSprite;

        float currentAngle = 0f;
        while (currentAngle < 180f)
        {
            float angle = rotateSpeed * Time.deltaTime;
            transform.Rotate(0f, angle, 0f);
            currentAngle += angle;
            yield return null;
        }

        transform.rotation = Quaternion.Euler(0f, 180f, 0f);

        yield return new WaitForSeconds(1f);
    }
}

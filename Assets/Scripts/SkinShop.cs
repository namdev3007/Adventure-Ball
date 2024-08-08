using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SkinShop : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public Image[] imageBnt;
    public Image previewImage;
    public GameObject[] lockIcons;

    public GameObject bntBuySkin;
    public GameObject notification;

    private bool isSkinPurchased = false;

    void Start()
    {
        for (int i = 0; i < imageBnt.Length; i++)
        {
            int characterIndex = i ; 

            if (characterIndex < characterDB.CharacterCount)
            {
                Character character = characterDB.GetCharacter(characterIndex);

                if (character.characterSprite != null)
                {
                    imageBnt[characterIndex].sprite = character.characterSprite;

                    imageBnt[characterIndex].GetComponent<Button>().onClick.AddListener(() => OnCharacterButtonClicked(characterIndex));
                    if (character.unlocked)
                    {
                        if (lockIcons != null && lockIcons.Length > characterIndex && lockIcons[characterIndex] != null)
                        {
                            lockIcons[characterIndex].SetActive(false);
                        }
                    }
                }
            }
        }

        for (int i = 0; i < 5 && i < characterDB.CharacterCount; i++)
        {
            if (characterDB.characters[i].unlocked)
            {
                isSkinPurchased = true;
                break;
            }
        }

        if (isSkinPurchased)
        {
            bntBuySkin.SetActive(false);
        }

    }
    private void OnCharacterButtonClicked(int characterIndex)
    {
        Character selectedCharacter = characterDB.GetCharacter(characterIndex);

        previewImage.sprite = selectedCharacter.characterSprite;
    }

    public void OnBuyPremiumSkinClicked()
    {
        for (int i = 0; i < 5 && i < characterDB.CharacterCount; i++)
        {
            characterDB.characters[i].unlocked = true;

            if (lockIcons != null && lockIcons.Length > i && lockIcons[i] != null)
            {
                lockIcons[i].SetActive(false);
            }
        }
        NotificationManager.instance.ActivateNotificationTrigger();
        isSkinPurchased = true;

        bntBuySkin.SetActive(false);

        StartCoroutine(TurnOffButtonAfterDelay());
    }

    private IEnumerator TurnOffButtonAfterDelay()
    {
        yield return new WaitForSeconds(2f); 

        notification.SetActive(false);
    }

}

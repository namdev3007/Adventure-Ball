using UnityEngine;
using UnityEngine.SceneManagement;

public class BuyPremiumSkin : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public GameObject bntBuySkin;

    private bool isSkinPurchased = false;

    void Start()
    {
        // Check if any of the first 5 characters is unlocked (assuming they are unlocked after purchasing)
        for (int i = 0; i < 5 && i < characterDB.CharacterCount; i++)
        {
            if (characterDB.characters[i].unlocked)
            {
                // If any of the first 5 characters is unlocked, set isSkinPurchased to true
                isSkinPurchased = true;
                break;
            }
        }

        // If skin is purchased, deactivate the buy skin button
        if (isSkinPurchased)
        {
            bntBuySkin.SetActive(false);
        }

    }

    public void OnBuyPremiumSkinClicked()
    {
        // Loop through the first 5 characters in the database
        for (int i = 0; i < 5 && i < characterDB.CharacterCount; i++)
        {
            // Mark the character as unlocked
            characterDB.characters[i].unlocked = true;
        }

        // Set isSkinPurchased to true after purchasing
        isSkinPurchased = true;

        // Deactivate the buy skin button
        bntBuySkin.SetActive(false);

        ReloadCurrentScene();
    }
    private void ReloadCurrentScene()
    {
        // Lấy tên của cảnh hiện tại
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Tải lại cảnh hiện tại bằng cách truyền tên của cảnh đó
        SceneManager.LoadScene(currentSceneName);
    }
}

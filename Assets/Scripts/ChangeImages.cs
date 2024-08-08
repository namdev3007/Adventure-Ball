using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImages : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public Image artworkImage; // Đổi SpriteRenderer thành Image

    private int selectedOption;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }
        UpdateCharacter(selectedOption);
    }

    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkImage.sprite = character.characterSprite; // Sử dụng sprite của Image thay vì SpriteRenderer
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
}

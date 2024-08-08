using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public SpriteRenderer artWorkSprite;

    private int selectedOption = 0;

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

    public void NextOption()
    {
        do
        {
            selectedOption++;
            if (selectedOption >= characterDB.CharacterCount)
            {
                selectedOption = 0;
            }
        } while (!characterDB.GetCharacter(selectedOption).unlocked); // Chỉ chọn skin đã mở khóa
        UpdateCharacter(selectedOption);
        Save();
    }

    public void BackOption()
    {
        do
        {
            selectedOption--;
            if (selectedOption < 0)
            {
                selectedOption = characterDB.CharacterCount - 1;
            }
        } while (!characterDB.GetCharacter(selectedOption).unlocked); // Chỉ chọn skin đã mở khóa
        UpdateCharacter(selectedOption);
    }

    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artWorkSprite.sprite = character.characterSprite;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }

    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

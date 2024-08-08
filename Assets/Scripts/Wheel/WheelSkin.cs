using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class WheelSkin : MonoBehaviour
{
    public GameObject[] Skin = new GameObject[3];

    public CharacterDatabase characterDatabase;

    void Start()
    {
        SetSkinSprites();
    }

    void SetSkinSprites()
    {
        Character character5 = characterDatabase.GetCharacter(4); 
        Character character6 = characterDatabase.GetCharacter(5); 
        Character character7 = characterDatabase.GetCharacter(6);

        AssignSpriteToGameObject(Skin[0], character5.characterSprite);
        AssignSpriteToGameObject(Skin[1], character6.characterSprite);
        AssignSpriteToGameObject(Skin[2], character7.characterSprite);
    }

    void AssignSpriteToGameObject(GameObject gameObject, Sprite sprite)
    {
        Image imageComponent = gameObject.GetComponent<Image>();
        imageComponent.sprite = sprite;
    }
}

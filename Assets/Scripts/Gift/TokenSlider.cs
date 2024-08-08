using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TokenSlider : MonoBehaviour
{
    public Slider slider; 
    public TextMeshProUGUI tokenText; 
    public int maxTokens = 6;

    public int characterIndex;
    public GameObject spriteSkin;

    public CharacterDatabase characterDatabase;
    private Token token;

    private void Awake()
    {
        token = GameObject.FindObjectOfType<Token>();
    }

    void Start()
    {
        UpdateSliderValue();
        SetSkinSprites();
    }

    private void Update()
    {
        UpdateSliderValue();
    }

    public void AddToken()
    {
        token.token++;

        PlayerPrefs.SetInt("Token", token.token);
        PlayerPrefs.Save();
    }

    private void UpdateSliderValue()
    {
        float fillAmount = (float)token.token / maxTokens;
        slider.value = fillAmount;

        tokenText.text = token.token + "/" + maxTokens;
    }

    private void SetSkinSprites()
    {
        Character character = characterDatabase.GetCharacter(characterIndex);

        AssignSpriteToGameObject(spriteSkin,character.characterSprite); 
    }

    void AssignSpriteToGameObject(GameObject gameObject, Sprite sprite)
    {
        Image imageComponent = gameObject.GetComponent<Image>();
        imageComponent.sprite = sprite;
    }

    public void BuySkin()
    {

    }    
}

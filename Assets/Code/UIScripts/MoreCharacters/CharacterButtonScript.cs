using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code
{
    public class CharacterButtonScript : MonoBehaviour
    {
        private static CharacterButtonScript equipedCharacter;
        
        private bool isPurchased = false;
        private string characterTag;
        private int price;

        [SerializeField] Text totalCoins = default;
        [SerializeField] private Text priceT = default;
        [SerializeField] private Text text = default;
        [SerializeField] Toggle isEquiped = default;
        [SerializeField] private Image coinImage = default;

        // Start is called before the first frame update
        void Start()
        {
            price = Int32.Parse(this.priceT.text);
            characterTag = this.tag;
            if (PlayerPrefs.HasKey(characterTag))
            {
                if (PlayerPrefs.GetString(characterTag) == StringConsts.EQUIPED)
                {
                    isEquiped.isOn = true;
                    equipedCharacter = this;
                }

                isPurchased = true;
                priceT.gameObject.SetActive(false);
                coinImage.gameObject.SetActive(false);
                text.gameObject.SetActive(true);
            }
            else
            {
                text.gameObject.SetActive(false);
                isEquiped.gameObject.SetActive(false);
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void OnClick()
        {
            if (isPurchased)
            {
                isEquiped.isOn = true;
                equipedCharacter.isEquiped.isOn = false;
                PlayerPrefs.SetString(equipedCharacter.characterTag, StringConsts.PURCHASED);
                
                equipedCharacter = this;
                PlayerPrefs.SetString(characterTag, StringConsts.EQUIPED);
                PlayerPrefs.SetString(StringConsts.CURRENT_CHARACTER, characterTag);
            }
            else
            {
                int coins = PlayerPrefs.GetInt(StringConsts.COINS);
                
                if (coins >= price)
                {
                    coins -= price;
                    PlayerPrefs.SetInt(StringConsts.COINS, coins);
                    priceT.gameObject.SetActive(false);
                    coinImage.gameObject.SetActive(false);
                    text.gameObject.SetActive(true);

                    PlayerCoinsScript.Instance.SetCoins(coins);
                    PlayerInstance.getInstance().CoinsText.text = coins.ToString();
                    
                    isPurchased = true;
                    isEquiped.gameObject.SetActive(true);
                    isEquiped.isOn = true;
                    equipedCharacter.isEquiped.isOn = false;
                    PlayerPrefs.SetString(equipedCharacter.characterTag, StringConsts.PURCHASED);
                    equipedCharacter = this;
                    PlayerPrefs.SetString(characterTag, StringConsts.EQUIPED);
                    PlayerPrefs.SetString(StringConsts.CURRENT_CHARACTER, characterTag);
                    CharacterControllerScript.ChangeCharacter(characterTag);
                }
            }
            PlayerPrefs.Save();
        }
    }
}

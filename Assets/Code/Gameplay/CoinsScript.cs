using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code
{
    public class CoinsScript : MonoBehaviour
    {
        private const int BRONZE_COIN = 1;
        private const int SILVER_COIN = 5;
        private const int GOLDEN_COIN = 10;
        private bool isShown = false;
        
        [SerializeField] Text coins = default;
        
        public bool IsShown
        {
            get => isShown;
            set => isShown = value;
        }

        // Start is called before the first frame update
        void Start()
        {
            switch(this.tag)
            {
                case "Bronze":
                    CoinsControll.BronzeCoin = this;
                    break;
                case "Silver":
                    CoinsControll.SilverCoin = this;
                    break;
                case "Golden":
                    CoinsControll.GoldenCoin = this;
                    break;
            }
            this.gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter2D(Collider2D other)
        {
            int addition = 0;

            switch(this.tag)
            {
                case "Bronze":
                    addition = BRONZE_COIN;
                    break;
                case "Silver":
                    addition = SILVER_COIN;
                    break;
                case "Golden":
                    addition = GOLDEN_COIN;
                    break;
            }
            
            PlayerPrefs.SetInt(StringConsts.COINS, PlayerPrefs.GetInt(StringConsts.COINS) + addition);
            PlayerPrefs.Save();
            coins.text = PlayerPrefs.GetInt(StringConsts.COINS).ToString();
            this.gameObject.SetActive(false);
        }
    }
}

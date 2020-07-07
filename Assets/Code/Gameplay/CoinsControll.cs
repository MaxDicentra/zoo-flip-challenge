using System;
using Assets.Code.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code
{
    public class CoinsControll: MonoBehaviour
    {
        private static CoinsScript goldenCoin;
        private static CoinsScript silverCoin;
        private static CoinsScript bronzeCoin;
        
        public static CoinsScript GoldenCoin
        {
            set => goldenCoin = value;
        }

        public static CoinsScript SilverCoin
        {
            set => silverCoin = value;
        }

        public static CoinsScript BronzeCoin
        {
            set => bronzeCoin = value;
        }
        
        void Update()
        {
            if (CollectablesController.Instance.Score != 0 && !goldenCoin.IsShown && !silverCoin.IsShown && !bronzeCoin.IsShown)
            {
                if (CollectablesController.Instance.Score % 10 == 0)
                {
                    goldenCoin.gameObject.SetActive(true);
                    goldenCoin.IsShown = true;
                    return;
                }
                if (CollectablesController.Instance.Score % 5 == 0)
                {    
                    silverCoin.gameObject.SetActive(true);
                    silverCoin.IsShown = true;
                    return;
                }
                if (CollectablesController.Instance.Score % 2 == 0)
                {
                    bronzeCoin.gameObject.SetActive(true);
                    bronzeCoin.IsShown = true;
                }
            }
        }
    }
}
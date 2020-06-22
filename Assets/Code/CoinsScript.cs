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
        
        [SerializeField] Text coins = default;
        
        private PlayerBehaviour player;
        // Start is called before the first frame update
        void Start()
        {
            player = PlayerInstance.getInstance();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            player.Coins = player.Coins + BRONZE_COIN;
            coins.text = player.Coins.ToString();
            this.gameObject.SetActive(false);
        }
    }
}

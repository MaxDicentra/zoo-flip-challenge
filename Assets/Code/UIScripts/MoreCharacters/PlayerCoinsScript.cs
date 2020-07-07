using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code
{
    public class PlayerCoinsScript : MonoBehaviour
    {
        private static PlayerCoinsScript instance;
        [SerializeField] private Text text = default;

        public static PlayerCoinsScript Instance
        {
            get => instance;
        }
        
        // Start is called before the first frame update
        void Start()
        {
            instance = this;
            SetCoins(PlayerPrefs.GetInt(StringConsts.COINS));
        }

        public void SetCoins(int coins)
        {
            text.text = coins.ToString();
        }
    }
}

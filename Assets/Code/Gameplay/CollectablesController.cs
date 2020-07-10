using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Gameplay
{
    public class CollectablesController: MonoBehaviour
    {
        [SerializeField] private Text currentScore = default;
        [SerializeField] private Text BestScoreText = default;
        [SerializeField] private Text coinsText = default;
        private int score = 0;

        private static CollectablesController instance;

        public Text CoinsText => coinsText;

        public static CollectablesController Instance => instance;

        public int Score => score;


        private void OnEnable()
        {
            PlatformScript.ScoreIncr += SetScore;
        }

        public void OnDisable()
        {
            PlatformScript.ScoreIncr -= SetScore;
        }

        void Awake()
        {
            //PlayerPrefs.DeleteAll();
            if (!PlayerPrefs.HasKey(StringConsts.COINS))
            {
                PlayerPrefs.SetInt(StringConsts.COINS, 200);
            }
            if (!PlayerPrefs.HasKey(StringConsts.BEST_SCORE))
            {
                PlayerPrefs.SetInt(StringConsts.BEST_SCORE, 0);
            }
            PlayerPrefs.Save();
            
            instance = this;
        }
        
        void Start()
        {
            BestScoreText.text = PlayerPrefs.GetInt(StringConsts.BEST_SCORE).ToString();
            coinsText.text = PlayerPrefs.GetInt(StringConsts.COINS).ToString();
        }
        
        void Update()
        {
        //    currentScore.text = score.ToString();
        }

        void SetScore()
        {
            score++;
            currentScore.text = score.ToString();
        }
    }
}
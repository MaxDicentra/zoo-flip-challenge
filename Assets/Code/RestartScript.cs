using Assets.Code;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets
{
    public class RestartScript : MonoBehaviour
    {
        [SerializeField] Rigidbody2D rb = default;
        [SerializeField] private Text results = default;
        
        private Vector2 finishPosition = new Vector2(150f,12f);
        private Vector2 speed = new Vector2(550f, 0f);

        // Start is called before the first frame update
        void Start()
        {
            EventsController.Restart = this;
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.x > finishPosition.x)
            {
                rb.velocity = Vector2.zero;
            }
        }

        public void Move()
        {
            results.text = "Final score: " + PlayerInstance.getInstance().Score + "\n" + 
                "Best score: " + PlayerInstance.getInstance().BestScore;
           
            PlayerPrefs.SetInt(StringConsts.BEST_SCORE, PlayerInstance.getInstance().BestScore);
            PlayerPrefs.SetInt(StringConsts.COINS, PlayerInstance.getInstance().Coins);
            rb.velocity = speed;
        }

        public void Restart()
        {
            EventsController.Spikes.Clear();
            EventsController.FreezableItems.Clear();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

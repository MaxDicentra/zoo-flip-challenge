using Assets.Code;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets
{
    public class RestartScript : MonoBehaviour
    {
        [SerializeField] private Text results = default;

        // Start is called before the first frame update
        void Start()
        {
            EventsController.Restart = this;
        }

        public void Move()
        {
            BasePanelScript.Instance.gameObject.SetActive(true);
            this.gameObject.SetActive(true);
            results.text = "Final score: " + PlayerInstance.getInstance().Score + "\n" + 
                "Best score: " + PlayerInstance.getInstance().BestScore;
           
            PlayerPrefs.SetInt(StringConsts.BEST_SCORE, PlayerInstance.getInstance().BestScore);
            PlayerPrefs.SetInt(StringConsts.COINS, PlayerInstance.getInstance().Coins);
        }

        public void Restart()
        {
            EventsController.Spikes.Clear();
            EventsController.FreezableItems.Clear();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

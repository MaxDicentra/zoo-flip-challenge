using System.Collections.Generic;
using Assets.Code;
using Assets.Code.Gameplay;
using Assets.Code.UIScripts.MoreCharacters;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets
{
    public class RestartScript : MonoBehaviour
    {
        [SerializeField] private Text results = default;
        

        void Awake()
        {
            EventsController.Restart = this;
        }

        public void Move()
        {
            BasePanelScript.Instance.gameObject.SetActive(true);
            this.gameObject.SetActive(true);

            if (CollectablesController.Instance.Score > PlayerPrefs.GetInt(StringConsts.BEST_SCORE))
            {
                PlayerPrefs.SetInt(StringConsts.BEST_SCORE, CollectablesController.Instance.Score);
            }
            PlayerPrefs.Save();
            
            results.text = "Final score: " + CollectablesController.Instance.Score + "\n" +
                           "Best score: " + PlayerPrefs.GetInt(StringConsts.BEST_SCORE);
        }

        public void Restart()
        {
            EventsController.FreezableItems = new List<IFreezable>();
            PlatformsController.Platforms = new List<PlatformScript>();

            PlayerPrefs.Save();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

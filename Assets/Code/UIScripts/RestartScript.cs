using System.Collections.Generic;
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
            BasePanelScript.Instance.gameObject.SetActive(false);
        }

        public void Move()
        {
            BasePanelScript.Instance.gameObject.SetActive(true);
            this.gameObject.SetActive(true);

            if (PlayerInstance.getInstance().Score > PlayerPrefs.GetInt(StringConsts.BEST_SCORE))
            {
                PlayerPrefs.SetInt(StringConsts.BEST_SCORE, PlayerInstance.getInstance().Score);
            }
            PlayerPrefs.Save();
            
            results.text = "Final score: " + PlayerInstance.getInstance().Score + "\n" +
                           "Best score: " + PlayerPrefs.GetInt(StringConsts.BEST_SCORE);
        }

        public void Restart()
        {
            EventsController.FreezableItems = new List<IFreezable>();
            PlatformsController.Platforms = new List<PlatformScript>();
            
            // delete
            CharacterControllerScript.CharactersList.Clear();
            
            
            PlayerPrefs.Save();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

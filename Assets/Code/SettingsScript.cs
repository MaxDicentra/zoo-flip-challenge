using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Code
{
    public class SettingsScript : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            ButtonsInstances.Settings = this;
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void Hide()
        {
            this.gameObject.SetActive(false);
        }
        
        public void OnClick()
        {
            SceneManager.LoadScene("settings");
        }
    }
}

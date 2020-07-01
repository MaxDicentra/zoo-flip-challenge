using UnityEngine;

namespace Assets.Code
{
    public class SettingsPanelScript : MonoBehaviour
    {
        private static SettingsPanelScript instance;

        public static SettingsPanelScript Instance
        {
            get => instance;
        }
    

        // Start is called before the first frame update
        void Start()
        {
            instance = this;
            this.gameObject.SetActive(false);
        }

        public void OnExitButtonClick()
        {
            BasePanelScript.Instance.gameObject.SetActive(false);
            BasePanelScript.Instance.gameObject.SetActive(false);
        }
    }
}

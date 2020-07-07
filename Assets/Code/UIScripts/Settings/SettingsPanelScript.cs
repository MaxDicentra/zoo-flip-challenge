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

        void Awake()
        {
            instance = this;
        }
        
        public void OnExitButtonClick()
        {
            this.gameObject.SetActive(false);
            BasePanelScript.Instance.gameObject.SetActive(false);
        }
    }
}

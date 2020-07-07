using Assets.Code.UIScripts.MoreCharacters;
using UnityEngine;

namespace Assets.Code
{
    public class BasePanelScript : MonoBehaviour
    {
        private static BasePanelScript instance;

        public static BasePanelScript Instance
        {
            get => instance;
        }

        void Awake()
        {
            instance = this;
        }
        
        // Start is called before the first frame update
        void Start()
        {
            MCPanelScript.Instance.gameObject.SetActive(false);
            SettingsPanelScript.Instance.gameObject.SetActive(false);
            instance.gameObject.SetActive(false);
        }
    }
}

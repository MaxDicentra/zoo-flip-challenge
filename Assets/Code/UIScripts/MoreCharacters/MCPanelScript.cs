using UnityEngine;

namespace Assets.Code.UIScripts.MoreCharacters
{
    public class MCPanelScript : MonoBehaviour
    {
        private static MCPanelScript instance;

        public static MCPanelScript Instance => instance;

        void Awake()
        {
            instance = this;
        }

        public void OnExitClick()
        {
            this.gameObject.SetActive(false);
            BasePanelScript.Instance.gameObject.SetActive(false);
        }
    }
}

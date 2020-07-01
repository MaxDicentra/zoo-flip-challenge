using UnityEngine;

namespace Assets.Code.UIScripts.MoreCharacters
{
    public class MCPanelScript : MonoBehaviour
    {
        private static MCPanelScript instance;

        public static MCPanelScript Instance => instance;

        // Start is called before the first frame update
        void Start()
        {
            instance = this;
            this.gameObject.SetActive(false);
        }

        public void OnExitClick()
        {
            this.gameObject.SetActive(false);
            BasePanelScript.Instance.gameObject.SetActive(false);
        }
    }
}

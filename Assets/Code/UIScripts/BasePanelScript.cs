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

        // Start is called before the first frame update
        void Start()
        {
            instance = this;
        }
    }
}

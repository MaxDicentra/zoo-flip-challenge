using UnityEngine;

namespace Assets.Code
{
    public class VKButtonScript : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            ButtonsInstances.VkButton = this;
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        
        public void Hide()
        {
            this.gameObject.SetActive(false);
        }
    }
}

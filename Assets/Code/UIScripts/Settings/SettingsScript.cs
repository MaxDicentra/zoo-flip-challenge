using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Assets.Code
{
    public class SettingsScript : MonoBehaviour //,  IPointerDownHandler, IPointerUpHandler
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
            BasePanelScript.Instance.gameObject.SetActive(true);
            SettingsPanelScript.Instance.gameObject.SetActive(true);
        }

        // public void OnPointerDown(PointerEventData eventData)
        // {
        //     throw new System.NotImplementedException();
        // }
        //
        // public void OnPointerUp(PointerEventData eventData)
        // {
        //     throw new System.NotImplementedException();
        // }
    }
}

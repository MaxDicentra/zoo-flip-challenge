using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Code
{
    public class MoreCharactersScript : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            ButtonsInstances.MoreCharacters = this;
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
            SceneManager.LoadScene("moreCharacters");
        }
    }
}

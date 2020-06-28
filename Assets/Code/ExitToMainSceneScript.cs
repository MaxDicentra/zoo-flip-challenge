using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Code
{
    public class ExitToMainSceneScript : MonoBehaviour
    {
        public void OnClick()
        {
            SceneManager.LoadScene("mainScene");
        }
    }
}

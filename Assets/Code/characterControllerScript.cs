using UnityEngine;

namespace Assets.Code
{
    public class characterControllerScript : MonoBehaviour
    {
        private Vector2 startPOsition = new Vector2(0f, -3.2f);
        // Start is called before the first frame update
        void Start()
        {
            if (PlayerPrefs.HasKey(StringConsts.CHARACTER))
            {
                var prefab = Resources.Load<GameObject>(PlayerPrefs.GetString(StringConsts.CHARACTER));
                var character = Instantiate<GameObject>(prefab, startPOsition, Quaternion.identity);
            }
            else
            {
                PlayerPrefs.SetString(StringConsts.CHARACTER, "0");
                var prefab = Resources.Load<GameObject>("0");
                var character = Instantiate<GameObject>(prefab, startPOsition, Quaternion.identity);
            }
        }
    }
}

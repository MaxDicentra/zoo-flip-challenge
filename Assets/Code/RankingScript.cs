using UnityEngine;

namespace Assets.Code
{
    public class RankingScript : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            ButtonsInstances.Ranking = this;
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

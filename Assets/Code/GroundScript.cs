using UnityEngine;

namespace Assets.Code
{
    public class GroundScript : MonoBehaviour
    {
        private const float MOVE_FORCE = 60f;
        private Vector2 startPosition;
        [SerializeField] private Rigidbody2D rb = default;
        
        // Start is called before the first frame update
        void Start()
        {
            startPosition = this.transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void FixedUpdate()
        {
            if (!PlayerInstance.getInstance().IsOnGround)
            {
                rb.isKinematic = false;
                rb.AddForce(Vector2.up * MOVE_FORCE);
            }
        }
        
    }
}

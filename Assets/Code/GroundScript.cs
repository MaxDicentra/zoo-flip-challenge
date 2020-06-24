using UnityEngine;

namespace Assets.Code
{
    public class GroundScript : MonoBehaviour
    {
        private const float MOVE_FORCE = -0.2f;
        private Vector2 startPosition;
        [SerializeField] private Rigidbody2D rb = default;
        
        // Start is called before the first frame update
        void Start()
        {
            rb.Sleep();
            startPosition = this.transform.position;
        }

        // Update is called once per frame
        void Update()
        {

        }

        void FixedUpdate()
        {
            if (!PlayerInstance.getInstance().IsOnGround && transform.position.y > startPosition.y - 15f)
            {
                rb.MovePosition(new Vector2(0f, transform.position.y + MOVE_FORCE));
            }
            
            // if (!PlayerInstance.getInstance().IsOnGround && transform.position.y > startPosition.y - 15f)
            // {
            //     rb.isKinematic = false;
            //     rb.AddForce(new Vector2(0f, MOVE_FORCE));
            // }
        }
    }
}

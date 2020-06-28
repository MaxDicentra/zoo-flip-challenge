using UnityEngine;

namespace Assets.Code
{
    public class GroundScript : MonoBehaviour
    {
        private const float MOVE_FORCE = -5f;
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
            if (transform.position.y > startPosition.y - 15f)
            {
                rb.velocity = Vector2.zero;
            }

        }

        void FixedUpdate()
        {
            if (!PlayerInstance.getInstance().IsOnGround && rb.velocity == Vector2.zero)
            {
                rb.velocity = new Vector2(0f, MOVE_FORCE);
            }
        }
    }
}

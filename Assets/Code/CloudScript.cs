using UnityEngine;

namespace Assets.Code
{
    public class CloudScript : MonoBehaviour
    {
        private const float MOVE_FORCE = -3f;
        private const float FINAL_POSITION = -10f;
        private const float START_POSITION = 11.5f;

        private Vector2 startPosition;
            
            
        [SerializeField] private Rigidbody2D rb = default;
        // Start is called before the first frame update
        void Start()
        {
            startPosition = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (this.transform.position.x < FINAL_POSITION)
            {
                rb.MovePosition(new Vector2(START_POSITION, startPosition.y));
            }
        }

        void FixedUpdate()
        {
            if (rb.velocity == Vector2.zero)
            {
                rb.velocity = new Vector2(MOVE_FORCE, 0f);
            }
        }
    }
}

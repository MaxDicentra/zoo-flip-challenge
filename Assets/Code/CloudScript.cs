using UnityEngine;

namespace Assets.Code
{
    public class CloudScript : MonoBehaviour, IFreezable
    {
        private const float MOVE_FORCE = -1.1f;
        private const float FINAL_POSITION = -11f;
        private const float START_POSITION = 11.5f;

        private Vector2 startPosition;
        private bool freezed = false;
            
            
        private Rigidbody2D rb;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            startPosition = transform.position;
            EventsController.AddToFreezableItems(this);
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
            if (!freezed)
            {
                if (rb.velocity == Vector2.zero)
                {
                    rb.velocity = new Vector2(MOVE_FORCE, 0f);
                }
            }
        }

        public void Freeze()
        {
            freezed = true;
            rb.velocity = Vector2.zero;
        }
    }
}

using System.Collections.Generic;
using Assets.Code.Gameplay;
using UnityEngine;

namespace Assets.Code
{
    public class PlatformScript : MonoBehaviour, IFreezable
    {
        public static System.Action ScoreIncr = delegate {  };
        
        private static bool isGameStarted = false;
        private List<Vector2> positions = new List<Vector2>(new []{new Vector2(0f,1f), 
            new Vector2(0f,2f),
            new Vector2(0f,3f)});
        private Vector2 JumpPos = new Vector2(0f,-2.4f);
        private Vector2 MovePosDown = new Vector2(0f,-8.5f);
        private Vector2 MovePosUp = new Vector2(0f,9f);
        private Vector2 HighVelocity = new Vector2(0f,  -9f);
        private Vector2 LowVelocity =  new Vector2(0f,  -1f);
        private Vector2 nextPos;

        private Rigidbody2D rigidBody;
        private BoxCollider2D collider;
        private float halfInterval = 0.5f;
        
        private bool hasPlayerOn = false;
        private bool isOnJumpPos = false;
        private bool isOnPosition = false;

        public BoxCollider2D Collider => collider;

        public Vector2 NextPos
        {
            get => nextPos;
            set => nextPos = value;
        }

        public bool HasPlayerOn
        {
            get => hasPlayerOn;
            set => hasPlayerOn = value;
        }

        public bool IsOnJumpPos
        {
            get => isOnJumpPos;
            set => isOnJumpPos = value;
        }

        public List<Vector2> Positions => positions;

        // Start is called before the first frame update
        void Start()
        {
            NextPos = positions[0];
            
            rigidBody = GetComponent<Rigidbody2D>();
            collider = GetComponent<BoxCollider2D>();
            
            PlatformsController.AddPlatform(this);
            EventsController.AddToFreezableItems(this);
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.y < NextPos.y + halfInterval && transform.position.y > NextPos.y - halfInterval &&
                !hasPlayerOn && !isOnPosition)
            {
                isOnPosition = true;
                rigidBody.velocity = Vector2.zero;
                this.collider.isTrigger = false;
            }
            
            if (transform.position.y < MovePosDown.y)
            {
                rigidBody.MovePosition(MovePosUp);
            }
            
            if (transform.position.y < JumpPos.y + halfInterval &&
                transform.position.y > JumpPos.y - halfInterval && hasPlayerOn && !isOnJumpPos)
            {
                rigidBody.velocity = LowVelocity;
                isOnJumpPos = true;
            }
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            if (PlayerInstance.getInstance().transform.position.y > transform.position.y && !hasPlayerOn)
            {
                PlayerInstance.getInstance().Grounded(transform);
                // PlayerInstance.getInstance().transform.SetParent(this.transform);
                // PlayerInstance.getInstance().IsOnPlatform = true;
                // PlayerInstance.getInstance().IsOnGround = false;
                
               // CollectablesController.Instance.Score += 1;
               ScoreIncr?.Invoke();
               
                hasPlayerOn = true;
                isOnPosition = false;
                isGameStarted = true;

                PlatformsController.CurrentPlatform = this;
                PlatformsController.GetOtherPlatform(this).MoveToPosition();
                // rigidBody.velocity = LowVelocity;
                rigidBody.velocity = HighVelocity;
            }
        }

        public void Freeze()
        {
            rigidBody.velocity = Vector2.zero;
        }

        private void MoveToPosition()
        {
            rigidBody.velocity = HighVelocity;
        }
    }
}

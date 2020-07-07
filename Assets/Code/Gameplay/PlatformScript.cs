using System.Collections.Generic;
using Assets.Code.Gameplay;
using UnityEngine;
using Random = System.Random;

namespace Assets.Code
{
    public class PlatformScript : MonoBehaviour, IFreezable
    {
        private static bool isGameStarted = false;

        private List<Vector2> positions = new List<Vector2>(new []{new Vector2(0f,1f), 
            new Vector2(0f,2f),
            new Vector2(0f,3f)});
        private Vector2 JumpPos = new Vector2(0f,-3.4f);
        private Vector2 MovePosDown = new Vector2(0f,-8.5f);
        private Vector2 MovePosUp = new Vector2(0f,9f);
        private Vector2 HighVelocity = new Vector2(0f,  -9f);
        private Vector2 LowVelocity =  new Vector2(0f,  -1f);
        private Vector2 NextPos;

        private Random rand;
        private Rigidbody2D rigidBody;
        private BoxCollider2D collider;
        private float halfInterval;
        
        private bool hasPlayerOn = false;
        private bool isOnJumpPos = false;
        private bool isOnPosition = false;
        
        // Start is called before the first frame update
        void Start()
        {
            NextPos = positions[0];
            halfInterval = HighVelocity.y / -2;
            
            rand = new Random();
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
                rigidBody.MovePosition(NextPos);
                isOnPosition = true;
                rigidBody.velocity = Vector2.zero;
            }
            
            if (transform.position.y < MovePosDown.y)
            {
                rigidBody.MovePosition(MovePosUp);
            }
            
            // if (transform.position.y < JumpPos.y + halfInterval &&
            //     transform.position.y > JumpPos.y - halfInterval && hasPlayerOn && !isOnJumpPos)
            // {
            //     rigidBody.velocity = LowVelocity;
            //     isOnJumpPos = true;
            // }
        }

        void OnCollisionExit2D(Collision2D other)
        {  
            // choosing next platform position
            if (PlayerInstance.getInstance().transform.position.y > transform.position.y) 
            {             
                PlayerInstance.getInstance().transform.SetParent(PlayerInstance.getInstance().MyParent);
                NextPos = positions[rand.Next(positions.Count)]; 
                hasPlayerOn = false;
                isOnJumpPos = false;
                
            }
        }
        
        void OnCollisionEnter2D(Collision2D other)
        {
            if (PlayerInstance.getInstance().transform.position.y > transform.position.y)
            {
                PlayerInstance.getInstance().transform.SetParent(this.transform);
                PlayerInstance.getInstance().IsOnPlatform = true;
                PlayerInstance.getInstance().IsOnGround = false;
                
                CollectablesController.Instance.Score += 1;
                
                hasPlayerOn = true;
                isOnPosition = false;
                isGameStarted = true;
                
                PlatformsController.GetOtherPlatform(this).MoveToPosition();
                rigidBody.velocity = LowVelocity;
                //rigidBody.velocity = HighVelocity;
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

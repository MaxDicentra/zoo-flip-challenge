using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Assets.Code;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour, IFreezable
{
    private const float FAST_MOVE_FORCE = -2f;
    private const float SlOW_MOVE_FORCE = -0.1f;
    private static bool isGameStarted = false;
    
    private Vector2 POSITION_1 = new Vector2(0f,1f);
    private Vector2 POSITION_2 = new Vector2(0f,3.60f);
    private Vector2 POSITION_3 = new Vector2(0f,4.8f);
    private Vector2 JumpPos = new Vector2(0f,-2.4f);
    private Vector2 MovePosDown = new Vector2(0f,-8.5f);
    private Vector2 MovePosUp = new Vector2(0f,9f);

    private Vector2 NextPos;


    private  BoxCollider2D collider;
    private Rigidbody2D rigidBody;
    private bool hasPlayerOn = false;

    public bool HasPlayerOn => hasPlayerOn;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        NextPos = POSITION_1;
        EventsController.AddToFreezableItems(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (!EventsController.FreezableItems.Contains(this))
        {
            EventsController.FreezableItems.Add(this);
        }
        if (!collider.isTrigger && hasPlayerOn)
        {
            if (transform.position.y > JumpPos.y)
            {
                rigidBody.velocity = new Vector2(0f, FAST_MOVE_FORCE);
            }
            else
            {
                rigidBody.velocity = new Vector2(0f, SlOW_MOVE_FORCE);
            }
        }
        else if(isGameStarted)
        {
            if (transform.position.y > MovePosDown.y && transform.position.y < NextPos.y)
            {
                rigidBody.velocity = new Vector2(0f, FAST_MOVE_FORCE);
            }
            else if(transform.position.y < NextPos.y)
            {
                rigidBody.MovePosition(MovePosUp);
            }
            else if(transform.position.y > NextPos.y)
            {
                rigidBody.velocity = new Vector2(0f, FAST_MOVE_FORCE);
            }
        }
    }

    void FixedUpdate()
    {
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerBehaviour>() != null && other.transform.position.y >= collider.transform.position.y)
        {
            collider.isTrigger = false;
            PlayerInstance.getInstance().IsOnPlatform = true;
            PlayerInstance.getInstance().IsOnGround = false;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {            
        //PlayerInstance.getInstance().transform.SetParent(PlayerInstance.getInstance().MyParent);
        collider.isTrigger = true;
        
        // choosing next platform position
        NextPos = POSITION_1;
        hasPlayerOn = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerInstance.getInstance().Score += 1;
        PlayerInstance.getInstance().transform.SetParent(this.transform);
        hasPlayerOn = true;
        isGameStarted = true;
    }

    public void Freeze()
    {
        rigidBody.velocity = Vector2.zero;
    }
}

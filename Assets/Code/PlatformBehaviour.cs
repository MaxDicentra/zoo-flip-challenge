using System.Collections;
using System.Collections.Generic;
using Assets.Code;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    [SerializeField] BoxCollider2D collider = default;
    [SerializeField] private Rigidbody2D rigidBody = default;

    private enum PlatformPositions
    {
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!collider.isTrigger)
        {
            // move platform etc
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
        collider.isTrigger = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerInstance.getInstance().Score += 1;
    }

    void MoveFast(Vector2 newPosition)
    {
        
    }

    void MoveSlow(Vector2 newPosition)
    {
        
    }
}

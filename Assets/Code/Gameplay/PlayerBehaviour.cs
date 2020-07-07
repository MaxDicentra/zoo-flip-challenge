using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Assets;
using Assets.Code;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class PlayerBehaviour : MonoBehaviour, IFreezable
{
    private const float JUMP_COEFFICIENT  = 500;
    
    private Rigidbody2D rigidBody;
    private Animator animator;
    
    [SerializeField] float jumpForceUnit = default;


    private Touch touch;
    private Transform myParent;
    
    private bool isGameStarted = false;
    private bool isOnPlatform = false;
    private bool isOnGround = true;
    private float direction;

    public Transform MyParent => myParent;
    
    public bool IsOnPlatform
    {
        get { return isOnPlatform;}
        set { isOnPlatform = value;}
    }

    public bool IsOnGround
    {
        get => isOnGround;
        set => isOnGround = value;
    }

    void Awake()
    {
        CharacterControllerScript.CharactersList.Add(this);

        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    
        myParent = this.transform.parent;
        EventsController.AddToFreezableItems(this);
        this.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        
    }

    public void Jump(float touchLength)
    {
        if (isOnPlatform || isOnGround)
        {
            isOnPlatform = false;
            if (touchLength < JUMP_COEFFICIENT)
            {
                rigidBody.AddForce(new Vector2(0f, jumpForceUnit));
            }
            else
            {
                rigidBody.AddForce(new Vector2(0f, jumpForceUnit * touchLength / JUMP_COEFFICIENT));
            }
        }
    }

    public void Freeze()
    {
        rigidBody.isKinematic = true;
    }

    public void MoveToPosition(Vector2 position)
    {
        rigidBody.MovePosition(position);
    }
}

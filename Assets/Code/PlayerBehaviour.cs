using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
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
    [SerializeField] private Text currentScore = default;


    private Touch touch;
    private Transform myParent;
    
    private bool isGameStarted = false;
    private bool isOnPlatform = false;
    private bool isOnGround = true;
    private float direction;
    private int coins = 0;
    private int bestScore = 0;
    private int score = 0;

    public Transform MyParent => myParent;

    public int Coins
    {
        get { return coins; }
        set { coins = value; }
    }

    public int BestScore
    {
        get => bestScore;
        set => bestScore = value;
    }

    public int Score
    {
        get => score;
        set => score = value;
    }

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

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        PlayerInstance.setInstance(this);
        myParent = this.transform.parent;
        EventsController.AddToFreezableItems(this);
    }

    // Update is called once per frame
    void Update()
    {   
        currentScore.text = score.ToString();
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
}

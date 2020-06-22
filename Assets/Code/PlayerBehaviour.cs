using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Assets.Code;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class PlayerBehaviour : MonoBehaviour
{
    private const float JUMP_COEFFICIENT  = 500;
    
    private Rigidbody2D rigidBody;
    private Animator animator;
    
    [SerializeField] float jumpForceUnit = default;
    [SerializeField] private Text currentScore = default;


    private Touch touch;
   
    private bool isGameStarted = false;
    private bool isOnPlatform = true;
    private bool hasReachedPl = false;
    private bool isOverPl = false;
    private float direction;
    [SerializeField] int coins = default;
    private int bestScore;
    [SerializeField] int score = 0;

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
        
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        PlayerInstance.setInstance(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentScore.text = score.ToString();
    }

    public void Jump(float touchLength)
    {
        if (isOnPlatform)
        {
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
}

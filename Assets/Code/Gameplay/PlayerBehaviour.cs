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
    [SerializeField] private Text coinsText = default;
    [SerializeField] private Text BestScoreText = default;


    private Touch touch;
    private Transform myParent;
    
    private bool isGameStarted = false;
    private bool isOnPlatform = false;
    private bool isOnGround = true;
    private float direction;
    private int score = 0;

    public Text CoinsText => coinsText;

    public Transform MyParent => myParent;

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

    void Awake()
    {
        //PlayerPrefs.DeleteAll();
        CharacterControllerScript.CharactersList.Add(this);
        
        if (!PlayerPrefs.HasKey(StringConsts.BEST_SCORE))
        {
            PlayerPrefs.SetInt(StringConsts.BEST_SCORE, 0);
        }
        if (!PlayerPrefs.HasKey(StringConsts.COINS))
        {
            PlayerPrefs.SetInt(StringConsts.COINS, 0);
        }
        PlayerPrefs.Save();
        
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    
        myParent = this.transform.parent;
        EventsController.AddToFreezableItems(this);
        this.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        coinsText.text = PlayerPrefs.GetInt(StringConsts.COINS).ToString();

        BestScoreText.text = PlayerPrefs.GetInt(StringConsts.BEST_SCORE).ToString();
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

    public void MoveToPosition(Vector2 position)
    {
        rigidBody.MovePosition(position);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Assets.Code;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class PlayerBehaviour : MonoBehaviour
{
    private const float JUMP_COEFFICIENT  = 500;
    
    private Rigidbody2D rigidBody;
    private Animator animator;
    
    [SerializeField] float jumpForceUnit = default;


    private Touch touch;
   
    private bool isGameStarted = false;
    private bool isLanded = true;
    private bool hasReachedPl = false;
    private bool isOverPl = false;
    private float direction;


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

    }

    public void Jump(float touchLength)
    {
        if (touchLength < JUMP_COEFFICIENT)
        {
            rigidBody.AddForce(new Vector2(0f, jumpForceUnit));
        }
        else
        {
            rigidBody.AddForce(new Vector2(0f, jumpForceUnit * touchLength / JUMP_COEFFICIENT));
        }
        
        // block touch until landing
    }
}

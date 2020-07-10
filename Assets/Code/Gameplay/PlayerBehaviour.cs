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
    [SerializeField] float jumpForceUnit = default;
    [SerializeField] private Animator animator;

    private Rigidbody2D rigidBody;
    private Transform myParent;
    private bool isOnPlatform = false;
    private bool isOnGround = true;

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

    public Animator Animator1 => animator;

    public void Jump(float touchLength)
    {
        if (rigidBody == null)
        {
            rigidBody = GetComponent<Rigidbody2D>();
            myParent = this.transform.parent;
        }
        
        if (isOnPlatform || isOnGround)
        {
            rigidBody.simulated = true;
            isOnPlatform = false;
            animator.SetBool("jump", false);
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

    public void Grounded(Transform _parent)
    {
        transform.SetParent(_parent);
        IsOnPlatform = true;
        IsOnGround = false;
        rigidBody.simulated = false;
    }
    
}

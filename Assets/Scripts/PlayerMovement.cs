using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    
    public bool playerHasHorizontalSpeed=true;
    public bool lastStandRight=true;

    void Start()
    {
        
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator= GetComponent<Animator>();
    }

    void Update()
    {
        
        Run();
        FlipSprite();

    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void Run()
    {

        Vector2 playerVelocity = new Vector2 (moveInput.x * runSpeed, moveInput.y *runSpeed);
        myRigidbody.velocity = playerVelocity;
        
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        bool isMovingUp = moveInput.y>0;

        myAnimator.SetBool("isRunning",playerHasHorizontalSpeed);
        myAnimator.SetBool("isRunningUp",isMovingUp);
        

        
    }

     void FlipSprite()
    {
        playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(myRigidbody.velocity.x), 1f);
            lastStandRight=true;
        }
        else
        {
            lastStandRight=false;
        }
    }



}


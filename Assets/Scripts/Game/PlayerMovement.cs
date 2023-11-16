using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    
    Vector2 moveInput;
    public Rigidbody2D myRigidbody;
    Animator myAnimator;
    public bool playerOnMove=false;
    public Vector3 position;


    public Vector3 bulletSpriteDirection= new Vector3(1f,0f,0f);

    public Vector3 bulletDirection;

    void Start()
    {
        
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator= GetComponent<Animator>();
    }

    void Update()
    {
        playerMoveCheck();
        Run();
        FlipSprite();
        BulletDirectionAfterMove();
        position = transform.position;

    }

    //test
    void BulletDirectionAfterMove()
    {
        if(myRigidbody.velocity.magnitude > 0.1f)
        {
            bulletDirection= myRigidbody.velocity.normalized;
        }
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
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
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    } 

        void playerMoveCheck()
    {
        if (myRigidbody.velocity.magnitude > 0.1f)
        {
            playerOnMove=true;
        }
    }

      public void GetUpdate(float x)
    {
        runSpeed += x;

    }

}


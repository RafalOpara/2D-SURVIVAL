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

/// te dwa ponizej do przepisania w funkcji oddzielnej
    public Vector3 playerDirection;
    public Vector3 lastPlayerDirection=new Vector3(1f,0f,0f);
    public Vector3 bulletDirection= new Vector3(1f,0f,0f);


    void Start()
    {
        
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator= GetComponent<Animator>();
    }

    void Update()
    {
        playerDirection=myRigidbody.velocity.normalized;
        playerMoveCheck();
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

    /*public Vector3 ShotDirection()
    {
        Vector3 WeaponDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        if(WeaponDirection!= Vector3.zero)
        {
            WeaponDirection=WeaponDirection.normalized;
        }
        else
        {
            float scaleX = transform.localScale.x;
            WeaponDirection= new Vector3(scaleX,0,0);
        }

        return WeaponDirection;
        
    }
 */
}


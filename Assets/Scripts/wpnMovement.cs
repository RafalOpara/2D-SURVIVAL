using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wpnMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    Vector2 direction;
    Vector2 lastDirection;
    

    PlayerMovement playerMovement;
    Rigidbody2D myRigidBody;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();

        playerMovement = FindObjectOfType<PlayerMovement>();
        direction = playerMovement.playerDirection; 

        
        SetDirectory();
        UpdateSpritePosition();
        
    }

    void SetDirectory()
    {
         myRigidBody.transform.localScale = new Vector3(1f, 1f);

        if(playerMovement.playerOnMove==false)
        {
            myRigidBody.velocity= new Vector3(1f,0f,0f)*speed;
        }

        else
        {

            if (direction.magnitude > 0.1f)  // Sprawdź, czy postać się rusza
            {
                myRigidBody.velocity = direction.normalized * speed;
                playerMovement.lastPlayerDirection=myRigidBody.velocity;
            }
            else
            {
                myRigidBody.velocity = playerMovement.lastPlayerDirection;
            }
            
        }

        playerMovement.bulletDirection=myRigidBody.velocity.normalized;
       
    }

    void UpdateSpritePosition()
    {
       
        float angle = Mathf.Atan2(playerMovement.bulletDirection.y, playerMovement.bulletDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }


    
}
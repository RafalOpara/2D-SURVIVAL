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
            myRigidBody.velocity = playerMovement.bulletDirection * speed;
        }

        playerMovement.bulletSpriteDirection=myRigidBody.velocity.normalized;
       
    }

    void UpdateSpritePosition()
    {
        float angle = Mathf.Atan2(playerMovement.bulletSpriteDirection.y, playerMovement.bulletSpriteDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }


    
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wpnGhostMovement : MonoBehaviour
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
            Vector2 direction = (playerMovement.position - transform.position).normalized;
            myRigidBody.velocity = direction * speed;
        
       
    }

    void UpdateSpritePosition()
    {
        float angle = Mathf.Atan2(playerMovement.bulletSpriteDirection.y, playerMovement.bulletSpriteDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }


    
}
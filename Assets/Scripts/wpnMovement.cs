using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wpnMovement : MonoBehaviour
{
    [SerializeField] float speedOnX=10f;
    float xSpeed;
    float direction;

    PlayerMovement playerMovement;
    Rigidbody2D myRigidBody;

    void Start()
    {
        myRigidBody=GetComponent<Rigidbody2D>();
        playerMovement=FindObjectOfType<PlayerMovement>();
        xSpeed= playerMovement.transform.localScale.x * speedOnX;
        direction=playerMovement.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        myRigidBody.transform.localScale=new Vector2 (direction,1f);
        myRigidBody.velocity=new Vector2(xSpeed,0f);
    }
}

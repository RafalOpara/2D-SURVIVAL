using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform targetDestination;
    GameObject targetGameobject;
    [SerializeField] float speed;
  

    Rigidbody2D rgdbd2d;

    private void Awake()
    {
        rgdbd2d=GetComponent<Rigidbody2D>();
        targetGameobject=targetDestination.gameObject;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rgdbd2d.velocity = direction * speed;
    }

    void Update()
    {
        FlipSprite();
    }

    void FlipSprite()
    {
        bool enemyHasHorizontalSpeed = Mathf.Abs(rgdbd2d.velocity.x) > Mathf.Epsilon;

        if (enemyHasHorizontalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(rgdbd2d.velocity.x), 1f);
        }
    }
}

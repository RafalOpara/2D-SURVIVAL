using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform targetDestination;
    GameObject targetGameobject;
    [SerializeField] float speed;
    float speedAfterSlow;
    [SerializeField] float dmg=10;
    private bool isTouchingPlayer = false;

    Rigidbody2D rgdbd2d;
    float timer;
    HealthPlayerController healthPlayerController;

    private void Awake()
    {
        rgdbd2d=GetComponent<Rigidbody2D>();
        healthPlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthPlayerController>();
        speedAfterSlow=speed;
    }

    public void SetTarget(GameObject target)
    {
        targetGameobject=target;
        targetDestination=target.transform;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rgdbd2d.velocity = direction * speed;
    }

    void Update()
    {
        FlipSprite();

        timer -= Time.deltaTime;
        if(timer<0f)
        {
            speed = speedAfterSlow;
        }
       
    }

    void FlipSprite()
    {
        bool enemyHasHorizontalSpeed = Mathf.Abs(rgdbd2d.velocity.x) > Mathf.Epsilon;

        if (enemyHasHorizontalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(rgdbd2d.velocity.x), 1f);
        }
    }

    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                isTouchingPlayer=true;
                InvokeRepeating("ApplyDamageToPlayer",0.1f,1f);
               
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouchingPlayer = false;
            CancelInvoke("ApplyDamageToPlayer");
        }
    }

    private void ApplyDamageToPlayer()
    {
        if (isTouchingPlayer)
        {
            healthPlayerController.TakeDamage(dmg);
        }
    }

    public void SlowEffect()
    {
        speed=speed /2;
        timer=2f;
    }

}

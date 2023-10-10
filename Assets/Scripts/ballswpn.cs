using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ballswpn : MonoBehaviour
{
    [SerializeField] GameObject lefthand;
    [SerializeField] GameObject righthand;
    [SerializeField] float timeToAttack=4f;
    float timer;

    PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement=FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0f)
        {
            Attack();
        }
    }

    void Attack()
    {
        timer=timeToAttack;

        if(playerMovement != null && playerMovement.lastStandRight == true)
        {
            lefthand.SetActive(true);
            righthand.SetActive(false);
        }
        else
        {
            righthand.SetActive(true);
            lefthand.SetActive(false);
        }
    }
}

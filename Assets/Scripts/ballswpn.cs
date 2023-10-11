using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ballswpn : MonoBehaviour
{
    [SerializeField] GameObject wpn2balls;
    [SerializeField] float timeToAttack=4f;
    Vector3 currentPosition;
    

    float timer;

    
    PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition=transform.position;

        timer -= Time.deltaTime;
        if(timer < 0f)
        {
            Attack();
        }
    }

    void Attack()
    {
        Instantiate(wpn2balls,currentPosition,transform.rotation);
        timer=timeToAttack;
    }
}

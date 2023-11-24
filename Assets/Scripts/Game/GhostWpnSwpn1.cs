using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GhostWpnSwpn : MonoBehaviour
{
    [SerializeField] GameObject wpn2balls;
    [SerializeField] float timeToAttack=4f;
    [SerializeField] public int dmg = 10;
    Vector3 currentPosition;
    
    PlayerMovement playerMovement;

    float timer;

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
        GameObject bullet = Instantiate(wpn2balls,currentPosition,Quaternion.identity);
        timer=timeToAttack;

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GhostWpnSpwn : MonoBehaviour
{
    [SerializeField] GameObject wpn2balls;
    [SerializeField] float timeToAttack=4f;
    [SerializeField] public float dmg = 10f;
    Vector3 currentPosition;
    


    float timer;

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
        GameObject bullet = Instantiate(wpn2balls,currentPosition,Quaternion.identity);
        timer=timeToAttack;

        
    }

}

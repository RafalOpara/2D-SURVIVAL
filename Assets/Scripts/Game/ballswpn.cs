using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ballswpn : MonoBehaviour
{
    [SerializeField] GameObject wpn2balls;
    [SerializeField] float timeToAttack=4f;
    [SerializeField] public float dmg = 10;
    Vector3 currentPosition;
    
    PlayerMovement playerMovement;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
      playerMovement = FindObjectOfType<PlayerMovement>();
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
        GameObject bullet = Instantiate(wpn2balls,currentPosition,Quaternion.identity);
        timer=timeToAttack;

        
    }

      public void GetUpdateAS(float x)
    {
        timeToAttack -= x;

    }

       public void GetUpdateDmg(float x)
    {
        dmg += x;

    }
}

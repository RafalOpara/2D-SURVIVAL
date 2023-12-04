using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WpnGhostBoostedDamage : MonoBehaviour
{
     float dmg;
    
    GhostWpnSpwn ghostWpnSpwn;
    HealthPlayerController healthPlayerController;
    PlayerMovement playerMovement;

    void Start()
    {
       ghostWpnSpwn = FindObjectOfType<GhostWpnSpwn>();
       playerMovement = FindObjectOfType<PlayerMovement>();
       dmg=ghostWpnSpwn.dmg;

       healthPlayerController=FindObjectOfType<HealthPlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag=="Player")
        {
            healthPlayerController.TakeDamage(dmg);
            playerMovement.SlowEffect();
            Destroy(gameObject);
            
            
        }

    
    }
   
}

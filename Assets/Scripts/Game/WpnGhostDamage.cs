using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WpnGhostDamage : MonoBehaviour
{
     float dmg;
    
    GhostWpnSpwn ghostWpnSpwn;
    HealthPlayerController healthPlayerController;

    void Start()
    {
       ghostWpnSpwn = FindObjectOfType<GhostWpnSpwn>();
       dmg=ghostWpnSpwn.dmg;

       healthPlayerController=FindObjectOfType<HealthPlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag=="Player")
        {
            healthPlayerController.TakeDamage(dmg);
            Destroy(gameObject);
            
        }

    
    }
   
}

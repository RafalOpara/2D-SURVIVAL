using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WpnDamage : MonoBehaviour
{
    [SerializeField] string wpntarget;

    float dmg;
    
    UpdateCharacter updateCharacter;
    ballswpn ballspwn;

    void Start()
    {
       ballspwn = FindObjectOfType<ballswpn>();
       updateCharacter = FindObjectOfType<UpdateCharacter>();

       dmg=ballspwn.dmg;

    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag==wpntarget)
        {
            EnemyDmgController enemyDmgController = other.GetComponent<EnemyDmgController>();
            Enemy enemy = other.GetComponent<Enemy>();
                {
                    enemyDmgController.TakeDamage(dmg);
                    if(updateCharacter.updateWpnSlow==true)
                    {
                      enemy.SlowEffect();
                    }
                }
                Destroy(gameObject);
        }
        
    }

   
}

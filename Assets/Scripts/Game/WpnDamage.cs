using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WpnDamage : MonoBehaviour
{
    [SerializeField] string wpntarger;

    int dmg;
    
    ballswpn ballspwn;

    void Start()
    {
       ballspwn = FindObjectOfType<ballswpn>();
       dmg=ballspwn.dmg;
    }

  private void OnTriggerEnter2D(Collider2D other) 
{
    if (other.tag==wpntarger)
    {
        EnemyDmgController enemyDmgController = other.GetComponent<EnemyDmgController>();
            {
                enemyDmgController.TakeDamage(dmg);
            }
            Destroy(gameObject);
        }
    }

   
}

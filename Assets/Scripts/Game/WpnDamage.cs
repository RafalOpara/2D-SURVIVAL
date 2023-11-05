using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WpnDamage : MonoBehaviour
{
    [SerializeField] int dmg = 10;

  private void OnTriggerEnter2D(Collider2D other) 
{
    if (other.tag=="Enemy")
    {
        EnemyDmgController enemyDmgController = other.GetComponent<EnemyDmgController>();
            {
                enemyDmgController.TakeDamage(dmg);
            }
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
     AudioManager audioManager;

    void Start()
    {
        audioManager=FindObjectOfType<AudioManager>();
    }
   
    private bool canBeActivatedAgain = false;

private void OnTriggerEnter2D(Collider2D other) 
{
    if ((other.tag == "Enemy" || other.tag == "enemyBullet") && !canBeActivatedAgain)
    {
        if(other.tag=="Enemy")
        {
            EnemyDmgController enemyDmgController = other.GetComponent<EnemyDmgController>();
            enemyDmgController.TakeDamage(30);
        }
        else
        {
            Destroy(other.gameObject);
        }

        gameObject.SetActive(false);
        canBeActivatedAgain = true;
        Invoke("ActivateGameObject", 5.0f); // Przykładowe opóźnienie przed ponownym aktywowaniem
        
    }
}

    private void ActivateGameObject()
    {
        canBeActivatedAgain = false;
        gameObject.SetActive(true);
        audioManager.PlaySFX(audioManager.getShield);

    }
}

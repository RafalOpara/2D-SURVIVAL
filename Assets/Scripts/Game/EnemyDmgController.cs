using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDmgController : MonoBehaviour
{
   private Color temporaryColor = new Color (255,0,0,255);
   private Color basicColor;
   private SpriteRenderer spriteRenderer;

   [SerializeField] public GameObject ExpBall;
   [SerializeField] float health= 100;

   float timer;

    AudioManager audioManager;

   void Start()
   {
      spriteRenderer=GetComponent<SpriteRenderer>();
      basicColor=spriteRenderer.color;
      audioManager=FindObjectOfType<AudioManager>();
   }

   void Update()
   {
      timer -= Time.deltaTime;

      if(timer < 0f)
      {
         spriteRenderer.color=basicColor;
      }
   }

   

   public void TakeDamage(float dmg)
   {
      audioManager.PlaySFX(audioManager.enemyTakeDmg);
     health-=dmg;
     spriteRenderer.color=temporaryColor;
      timer=0.3f;
      
      
     if(health<=0)
     {
        Destroy(gameObject);
        Vector3 position = transform.position;
        GameObject newExpBall = Instantiate(ExpBall,position,Quaternion.identity);
        audioManager.PlaySFX(audioManager.killEnemy);
         
     }

      
   }
}

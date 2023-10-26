using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthPlayerController : MonoBehaviour

{   
    private Color temporaryColor = new Color (255,0,0,255);
    private Color basicColor;
    private SpriteRenderer spriteRenderer;

    [SerializeField] float health=100;
    [SerializeField] float maxHelath=100;
    [SerializeField] PlayerHealthBar playerHealthBar;
   

    float timer;

     void Start()
   {
      spriteRenderer=GetComponent<SpriteRenderer>();
      basicColor=spriteRenderer.color;
      playerHealthBar=GetComponentInChildren<PlayerHealthBar>();
      playerHealthBar.UpdateHealthBar(health,maxHelath);

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
     health-=dmg;
     spriteRenderer.color=temporaryColor;
      playerHealthBar.UpdateHealthBar(health,maxHelath);

      timer=0.3f;
      
     if(health<=0)
     {
        Destroy(gameObject);
     }

      
   }
}

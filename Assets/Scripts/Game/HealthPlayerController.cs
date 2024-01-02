using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthPlayerController : MonoBehaviour

{   
    private Color temporaryColor = new Color (255,0,0,255);
    private Color basicColor;
    private SpriteRenderer spriteRenderer;

    AudioManager audioManager;


    [SerializeField] public float health=100;
    [SerializeField] float maxHelath=100;
    [SerializeField] PlayerHealthBar playerHealthBar;
   

    float timer;

     void Start()
   {
      spriteRenderer=GetComponent<SpriteRenderer>();
      basicColor=spriteRenderer.color;
      playerHealthBar=GetComponentInChildren<PlayerHealthBar>();
      playerHealthBar.UpdateHealthBar(health,maxHelath);
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
     health-=dmg;
     spriteRenderer.color=temporaryColor;
     playerHealthBar.UpdateHealthBar(health,maxHelath);
     audioManager.PlaySFX(audioManager.getDmg);


      timer=0.3f;
      
     if(health<=0)
     {
        Destroy(gameObject);
        SceneManager.LoadSceneAsync(0);

     }

      
   }

     public void GetUpdate(float x)
    {
        maxHelath += x;

    }
}

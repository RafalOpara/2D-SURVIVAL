using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{   
    [SerializeField] GameObject pink_slime;
     [SerializeField] GameObject pink_slimeBoosted;

    [SerializeField] GameObject wolf;
    [SerializeField] GameObject ghost;
    [SerializeField] GameObject rat;

    [SerializeField] GameObject green_slime;
    [SerializeField] GameObject green_slimeBoosted;

    [SerializeField] Vector2 spawnArea;
/// <summary>
/// ////////////////////////////////////////////////////////
/// </summary>
    [SerializeField] float pink_slimeTimer;
    [SerializeField] float pink_slimeBoostedTimer;


    [SerializeField] float ghost_Timer;
    [SerializeField] float wolf_Timer;
    [SerializeField] float rat_Timer;

    [SerializeField] float green_slimeTimer;
    [SerializeField] float green_slimeBoostedTimer;
   /// <summary>
   /// /////////////////////////////////////////////////////
   /// </summary>

    [SerializeField] GameObject player;
    float timeInGame;

    System.Random rand = new System.Random();

    UpdateCharacter updateCharacter;

    void Start()
    {
        updateCharacter=FindObjectOfType<UpdateCharacter>();
        timeInGame=updateCharacter.timeInGame;

        pink_slimeTimer=-1;
        pink_slimeBoostedTimer=-1;

        wolf_Timer=-1;
        ghost_Timer=-1;
        rat_Timer=-1;

        green_slimeTimer=-1;
        green_slimeBoostedTimer=-1;

    }

    private void Update()
    {
        timeInGame=updateCharacter.timeInGame;

     
            pinkSlimeSpawn();
            pinkSlimeBoostedSpawn();
            wolfSpawn();
            ghostSpawn();
            ratSpawn();
            greenSlimeSpawn();
            greenSlimeBoostedSpawn();
            updateTimeOfSpawnMonsters();
        

    }

    private void SpawnEnemy(GameObject x)
    {

        Vector3 position = new Vector3(
            UnityEngine.Random.Range(-spawnArea.x, spawnArea.x),
            UnityEngine.Random.Range(-spawnArea.y, spawnArea.y),
            0f
            );

        GameObject newEnemy = Instantiate(x);
        newEnemy.transform.position = position;
        newEnemy.GetComponent<Enemy>().SetTarget(player);
    }

    int minTimeForSpawnPinkSlime=5;
    int maxTimeForSpawnPinkSlime=10;

    private void pinkSlimeSpawn() ///15 hp
    {   
        pink_slimeTimer -= Time.deltaTime;
        if(pink_slimeTimer<0)
        {
            SpawnEnemy(pink_slime);
            pink_slimeTimer=rand.Next(minTimeForSpawnPinkSlime,maxTimeForSpawnPinkSlime);
        }
    }

     int minTimeForSpawnPinkSlimeBoosted=10;
     int maxTimeForSpawnPinkSlimeBoosted=25;

     private void pinkSlimeBoostedSpawn() ///20 hp
    {   
        if(timeInGame>420f)
        {

            pink_slimeBoostedTimer -= Time.deltaTime;
            if(pink_slimeBoostedTimer<0)
            {
                SpawnEnemy(pink_slimeBoosted);
                pink_slimeBoostedTimer=rand.Next(minTimeForSpawnPinkSlimeBoosted,maxTimeForSpawnPinkSlimeBoosted);
            }
        }
    }


    int minTimeForSpawnGhost=11;
    int maxTimeForSpawnGhost=18;

     private void ghostSpawn() //20 hp
    {
        if(timeInGame>60f)
        {
            ghost_Timer-=Time.deltaTime;
            if(ghost_Timer<0)
            {
                SpawnEnemy(ghost);
                ghost_Timer=rand.Next(minTimeForSpawnGhost,maxTimeForSpawnGhost);
            }
        }
    }



    int minTimeForSpawnWolf=10;
    int maxTimeForSpawnWolf=15;

     private void wolfSpawn() //30 hp
    {
        if(timeInGame>600f)
        {
            wolf_Timer-=Time.deltaTime;
            if(wolf_Timer<0)
            {
                SpawnEnemy(wolf);
                wolf_Timer=rand.Next(minTimeForSpawnWolf,maxTimeForSpawnWolf);
            }
        }
    }

    

    int minTimeForSpawnRat=15;
    int maxTimeForSpawnRat=40;

     private void ratSpawn() // 10 hp
    {
        if(timeInGame>180f)
        {
            rat_Timer-=Time.deltaTime;
            if(rat_Timer<0)
            {
                SpawnEnemy(rat);
                rat_Timer=rand.Next(minTimeForSpawnRat,maxTimeForSpawnRat);
            }
        }
    }

    int minTimeForSpawnGreenSlime=60;
    int maxTimeForSpawnGreenSlime=80;

     private void greenSlimeSpawn() // 60 hp 
    {
        if(timeInGame>500f)
        {
            green_slimeTimer-=Time.deltaTime;
            if(green_slimeTimer<0)
            {
                SpawnEnemy(green_slime);
                green_slimeTimer=rand.Next(minTimeForSpawnGreenSlime,maxTimeForSpawnGreenSlime);
            }
        }
    }

    int minTimeForSpawnGreenSlimeBoosted=99999;
    int maxTimeForSpawnGreenSlimeBoosted=99999;

     private void greenSlimeBoostedSpawn() // 150 hp 
    {
        if(timeInGame>380f)
        {
            green_slimeBoostedTimer-=Time.deltaTime;
            if(green_slimeBoostedTimer<0)
            {
                SpawnEnemy(green_slimeBoosted);
                green_slimeBoostedTimer=rand.Next(minTimeForSpawnGreenSlimeBoosted,maxTimeForSpawnGreenSlimeBoosted);
            }
        }
    }

   private void updateTimeOfSpawnMonsters()
    {
        ///pinkSlime
        if(timeInGame==60f)
        {
             minTimeForSpawnPinkSlime=4;
             maxTimeForSpawnPinkSlime=9;
        }

         if(timeInGame==120f)
        {
             minTimeForSpawnPinkSlime=3;
             maxTimeForSpawnPinkSlime=8;
        }

          if(timeInGame==240f)
        {
             minTimeForSpawnPinkSlime=3;
             maxTimeForSpawnPinkSlime=6;
        }

         if(timeInGame==500f)
        {
             minTimeForSpawnPinkSlime=3;
             maxTimeForSpawnPinkSlime=5;
        }

        //pinkSlimeBoosted
        if(timeInGame==480f)
        {
            minTimeForSpawnPinkSlimeBoosted=8;
            maxTimeForSpawnPinkSlimeBoosted=20;
        }


        //ghost

          if(timeInGame==180f)
        {
            minTimeForSpawnGhost=9;
            maxTimeForSpawnGhost=17;
        }

          if(timeInGame==240f)
        {
            minTimeForSpawnGhost=8;
            maxTimeForSpawnGhost=15;
        }
          if(timeInGame==420f)
        {
            minTimeForSpawnGhost=6;
            maxTimeForSpawnGhost=12;
        }
        
    }
  

}

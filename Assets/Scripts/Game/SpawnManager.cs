using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{   
    [SerializeField] GameObject pink_slime;
    [SerializeField] GameObject wolf;
    [SerializeField] GameObject ghost;
    [SerializeField] GameObject rat;
    [SerializeField] GameObject green_slime;

    [SerializeField] Vector2 spawnArea;

    [SerializeField] float pink_slimeTimer;
    [SerializeField] float ghost_Timer;
    [SerializeField] float wolf_Timer;
    [SerializeField] float rat_Timer;
    [SerializeField] float green_slimeTimer;
   

    [SerializeField] GameObject player;
    float timeInGame;

    System.Random rand = new System.Random();

    UpdateCharacter updateCharacter;

    void Start()
    {
        updateCharacter=FindObjectOfType<UpdateCharacter>();
        timeInGame=updateCharacter.timeInGame;

        pink_slimeTimer=rand.Next(4,10);
        wolf_Timer=rand.Next(60,120);
        ghost_Timer=rand.Next(10,30);
        rat_Timer=rand.Next(10,30);
        green_slimeTimer=rand.Next(80,160);

    }

    private void Update()
    {
        timeInGame=updateCharacter.timeInGame;

     
            pinkSlimeSpawn();
            wolfSpawn();
            ghostSpawn();
            ratSpawn();
            greenSlimeSpawn();
        

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

    private void pinkSlimeSpawn()
    {   
        pink_slimeTimer -= Time.deltaTime;
        if(pink_slimeTimer<0)
        {
            SpawnEnemy(pink_slime);
            pink_slimeTimer=rand.Next(4,10);
        }
    }

     private void wolfSpawn()
    {
        wolf_Timer-=Time.deltaTime;
        if(wolf_Timer<0)
        {
            SpawnEnemy(wolf);
            wolf_Timer=rand.Next(60,120);
        }
    }

     private void ghostSpawn()
    {
        ghost_Timer-=Time.deltaTime;
        if(ghost_Timer<0)
        {
            SpawnEnemy(ghost);
            ghost_Timer=rand.Next(10,30);
        }
    }

     private void ratSpawn()
    {
        rat_Timer-=Time.deltaTime;
        if(rat_Timer<0)
        {
            SpawnEnemy(rat);
            rat_Timer=rand.Next(10,30);
        }
        
    }

     private void greenSlimeSpawn()
    {
        green_slimeTimer-=Time.deltaTime;
        if(green_slimeTimer<0)
        {
            SpawnEnemy(green_slime);
            green_slimeTimer=rand.Next(80,160);
        }
       
    }
  

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpRed : MonoBehaviour
{
    bool wasCollected = false;
   [SerializeField] int value= 5;

    UpdateCharacter updateCharacter;

    void Start()
    {
        updateCharacter = FindObjectOfType<UpdateCharacter>();
    }

     void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag== "Player" && !wasCollected)
        {
            wasCollected=true;
            Debug.Log("Gracz dotknął tego obiektu!");
            gameObject.SetActive(false);
            Destroy(gameObject);
            updateCharacter.GetExp(value);
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSlow : MonoBehaviour
{
    bool wasCollected = false;

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
            gameObject.SetActive(false);
            Destroy(gameObject);
            updateCharacter.updateWpnSlow=true;
            
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialDropShield : MonoBehaviour
{
    [SerializeField] public GameObject specialDrop;

    UpdateCharacter updateCharacter;
    EnemyDmgController enemyDmgController;


    void Start()
    {
        updateCharacter=FindObjectOfType<UpdateCharacter>();
        enemyDmgController=FindObjectOfType<EnemyDmgController>();

        if(updateCharacter.updateShield==false)
        {
            enemyDmgController.ExpBall=specialDrop;
        }

    }
}

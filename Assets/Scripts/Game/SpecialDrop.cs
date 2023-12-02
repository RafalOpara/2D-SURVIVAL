using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialDrop : MonoBehaviour
{
    [SerializeField] public GameObject specialDrop;

    UpdateCharacter updateCharacter;
    EnemyDmgController enemyDmgController;


    void Start()
    {
        updateCharacter=FindObjectOfType<UpdateCharacter>();
        enemyDmgController=FindObjectOfType<EnemyDmgController>();

        if(updateCharacter.updateWpnSlow==false)
        {
            enemyDmgController.ExpBall=specialDrop;
        }

    }
}

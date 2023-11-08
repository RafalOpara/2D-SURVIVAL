using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCharacter : MonoBehaviour
{
    [SerializeField] int currentExp;
    [SerializeField] int maxExp;
    [SerializeField] int currentLvl;


    [SerializeField] int updateAttackSpeedValue=1;
    [SerializeField] int updateDmg =1;
    [SerializeField] float updateMaxHalth=1f;
    [SerializeField] float updateMovementSpeed=1f;

    public static bool GameIsPaused=false;
    public GameObject pauseMenuUi;

    ballswpn ballswpn;
    WpnDamage wpnDamage;
    HealthPlayerController healthPlayerController;
    PlayerMovement playerMovement;


    void Start()
    {
        ballswpn=FindObjectOfType<ballswpn>();
        wpnDamage=FindObjectOfType<WpnDamage>();
        healthPlayerController=FindObjectOfType<HealthPlayerController>();
        playerMovement=FindObjectOfType<PlayerMovement>();

    }

    public void GetExp(int x)
    {
        currentExp += x;
        if(currentExp>=maxExp)
        {
            Pause();
            currentExp=currentExp-maxExp;
            currentLvl++;
        }

    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume ()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale=1f;
        GameIsPaused=false;
    }

    void Pause ()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused=true;
    }

   public void UpdateAttackSpeed()
    {
        ballswpn.GetUpdate(updateAttackSpeedValue);
        Resume();
    }
    public void UpdateDmg()
    {
        wpnDamage.GetUpdate(updateDmg);
    }
    public void UpdateMaxHalth()
    {
        healthPlayerController.GetUpdate(updateMaxHalth);
    }
    public void UpdateMovementSpeed()
    {
        playerMovement.GetUpdate(updateMovementSpeed);
    }
    
    
}

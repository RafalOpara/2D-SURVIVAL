using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateCharacter : MonoBehaviour
{


    public float timeInGame=0f;

    [SerializeField] float currentExp;
    [SerializeField] float maxExp;
    [SerializeField] float currentLvl;


    [SerializeField] float updateAttackSpeedValue=1;
    [SerializeField] float updateDmg =1;
    [SerializeField] float updateMaxHalth=1f;
    [SerializeField] float updateMovementSpeed=1f;


     float currentupdateAttackSpeedValue=0;
     float currentupdateDmg =0;
     float currentupdateMaxHalth=0f;
     float currentupdateMovementSpeed=0f;

    [SerializeField] TextMeshProUGUI lvlText;

    [SerializeField] TextMeshProUGUI currentAttackSpeedText;
    [SerializeField] TextMeshProUGUI currentDmgText;
    [SerializeField] TextMeshProUGUI currentMaxHealthText;
    [SerializeField] TextMeshProUGUI currentMovementSpeedText;
    [SerializeField] TextMeshProUGUI currentTimeInGame;

    public static bool GameIsPaused=false;
    public GameObject pauseMenuUi;

    ballswpn ballswpn;
    WpnDamage wpnDamage;
    HealthPlayerController healthPlayerController;
    PlayerMovement playerMovement;
    ExpBar expBar;


    void Start()
    {
        ballswpn=FindObjectOfType<ballswpn>();
        wpnDamage=FindObjectOfType<WpnDamage>();
        healthPlayerController=FindObjectOfType<HealthPlayerController>();
        playerMovement=FindObjectOfType<PlayerMovement>();
        expBar=FindObjectOfType<ExpBar>();
        expBar.UpdateExpBar(currentExp,maxExp);

        lvlText.text="Level:" + currentLvl.ToString();
        currentAttackSpeedText.text="Attack speed: " + currentupdateAttackSpeedValue.ToString();
        currentDmgText.text="Damage: " + currentupdateDmg.ToString();
        currentMaxHealthText.text="Health: " + currentupdateMaxHalth.ToString();
        currentMovementSpeedText.text="Speed: " + currentupdateMovementSpeed.ToString();
        currentTimeInGame.text=timeInGame.ToString("0,0");

    }

    public void GetExp(int x)
    {
        currentExp += x;
        

        if(currentExp>=maxExp)
        {
            Pause();
            currentExp=currentExp-maxExp;
            currentLvl++;
            lvlText.text="Level:" + currentLvl.ToString();
            maxExp+=5;
            if(healthPlayerController.health<100f)
            {
                healthPlayerController.health+=50f;
                if(healthPlayerController.health>100f)
                {
                    healthPlayerController.health=100f;
                }
            }
            
        }

        expBar.UpdateExpBar(currentExp,maxExp);

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
        UpdateTimeInGame();
        
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
/// 
   public void UpdateAttackSpeed()
    {
        ballswpn.GetUpdateAS(updateAttackSpeedValue);
         currentupdateAttackSpeedValue+=updateAttackSpeedValue;
        currentAttackSpeedText.text="Attack speed: +"+ currentupdateAttackSpeedValue.ToString();
        Resume();
       
    }
    public void UpdateDmg()
    {
        ballswpn.GetUpdateDmg(updateDmg);
        currentupdateDmg+=updateDmg;
        currentDmgText.text="Damage: +" + currentupdateDmg.ToString();
        Resume();
        
    }
    public void UpdateMaxHalth()
    {
        healthPlayerController.GetUpdate(updateMaxHalth);
        currentupdateMaxHalth+=updateMaxHalth;
        currentMaxHealthText.text="Health: +" + currentupdateMaxHalth.ToString();
        Resume();
        
    }
    public void UpdateMovementSpeed()
    {
        playerMovement.GetUpdate(updateMovementSpeed);
        currentupdateMovementSpeed+=updateMovementSpeed;
        currentMovementSpeedText.text="Speed: +" + currentupdateMovementSpeed.ToString();
        Resume();
        
    }
    
    void UpdateTimeInGame()
    {
        timeInGame += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timeInGame/60);
        int seconds = Mathf.FloorToInt(timeInGame % 60);
        currentTimeInGame.text=string.Format("{0:00}:{1:00}",minutes,seconds);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateCharacter : MonoBehaviour
{
    [SerializeField] float currentExp;
    [SerializeField] float maxExp;
    [SerializeField] float currentLvl;


    [SerializeField] int updateAttackSpeedValue=1;
    [SerializeField] int updateDmg =1;
    [SerializeField] float updateMaxHalth=1f;
    [SerializeField] float updateMovementSpeed=1f;


     int currentupdateAttackSpeedValue=0;
     int currentupdateDmg =0;
     float currentupdateMaxHalth=0f;
     float currentupdateMovementSpeed=0f;

    [SerializeField] TextMeshProUGUI lvlText;

    [SerializeField] TextMeshProUGUI currentAttackSpeedText;
    [SerializeField] TextMeshProUGUI currentDmgText;
    [SerializeField] TextMeshProUGUI currentMaxHealthText;
    [SerializeField] TextMeshProUGUI currentMovementSpeedText;

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
            maxExp+=15;
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
        ballswpn.GetUpdate(updateAttackSpeedValue);
         currentupdateAttackSpeedValue+=updateAttackSpeedValue;
        currentAttackSpeedText.text="Attack speed: +"+ currentupdateAttackSpeedValue.ToString();
        Resume();
       
    }
    public void UpdateDmg()
    {
        ballswpn.GetUpdate(updateDmg);
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
    
    
}
